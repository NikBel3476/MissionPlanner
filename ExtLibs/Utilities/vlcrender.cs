﻿using LibVLC.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using SkiaSharp;

namespace MissionPlanner.Utilities
{
    public class vlcrender
    {
        public static List<vlcrender> store = new List<vlcrender>();

        LibVLCLibrary library;
        IntPtr inst, mp, m;
        int Width, Height;

        LibVLCLibrary.libvlc_video_lock_cb vlc_lock_delegate;
        LibVLCLibrary.libvlc_video_unlock_cb vlc_unlock_delegate;
        LibVLCLibrary.libvlc_video_display_cb vlc_picture_delegate;
        LibVLCLibrary.libvlc_video_format_cb vlc_video_format_delegate;
        LibVLCLibrary.libvlc_video_cleanup_cb vlc_video_cleanup_delegate;

        private static event EventHandler<System.Drawing.Bitmap> _onNewImage;
        public static event EventHandler<System.Drawing.Bitmap> onNewImage
        {
            add { _onNewImage += value; }
            remove { _onNewImage -= value; }
        }

        public string playurl = "rtsp://192.168.1.253:554/Streaming/Channels/1";

        public void Start(int forceWidth = 0, int forceHeight = 0)
        {
            if (store.Count > 0)
                store[0].Stop();

            store.Add(this);

            library = LibVLCLibrary.Load(null);
            
            inst = library.m_libvlc_new(4,
                new string[] {":sout-udp-caching=0", ":udp-caching=0", ":rtsp-caching=0", ":tcp-caching=0"});
                //libvlc_new()                                    // Load the VLC engine 
            m = library.libvlc_media_new_location(inst, playurl);

            // Create a new player
            mp = library.libvlc_media_player_new_from_media(m); // Create a media player playing environement 
            library.libvlc_media_release(m); // No need to keep the media now 

            vlc_lock_delegate = new LibVLCLibrary.libvlc_video_lock_cb(vlc_lock);
            vlc_unlock_delegate = new LibVLCLibrary.libvlc_video_unlock_cb(vlc_unlock);
            vlc_picture_delegate = new LibVLCLibrary.libvlc_video_display_cb(vlc_picture);

            library.libvlc_video_set_callbacks(mp,
                vlc_lock_delegate,
                vlc_unlock_delegate,
                vlc_picture_delegate);

            if (forceWidth != 0 && forceHeight != 0)
            {
                this.Width = forceWidth;
                this.Height = forceHeight;

                library.libvlc_video_set_format(this.mp, "RV32", (uint)Width, (uint)Height, (uint)Width * 4);
            }
            else
            {
                vlc_video_format_delegate = Setup;
                vlc_video_cleanup_delegate = Cleanup;

                library.libvlc_video_set_format_callbacks(mp, vlc_video_format_delegate, vlc_video_cleanup_delegate);
            }

            library.libvlc_media_player_play(mp); // play the media_player 
        }

        private uint Setup(ref IntPtr opaque, ref uint chroma, ref uint width, ref uint height, ref uint pitches, ref uint lines)
        {
            this.Width = (int)width;
            this.Height = (int)height;
            chroma = BitConverter.ToUInt32(new byte[] { (byte)'R', (byte)'V', (byte)'3', (byte)'2' }, 0);
            pitches = width * 4;

            if (imageIntPtr == IntPtr.Zero)
                imageIntPtr = Marshal.AllocHGlobal(Width * 4 * Height);

            return 1;
        }

        private void Cleanup(IntPtr opaque)
        {
            if (imageIntPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(imageIntPtr);
                imageIntPtr = IntPtr.Zero;
            }
        }

        public void Stop()
        {
            store.Remove(this);

            if (library == null)
                return;

            library.libvlc_media_player_stop(mp);                             // Stop playing 
            library.libvlc_media_player_release(mp);                          // Free the media_player 
            library.libvlc_release(inst);

            LibVLCLibrary.Free(library);

            library = null;

            if (imageIntPtr != IntPtr.Zero)
                Marshal.FreeHGlobal(imageIntPtr);
        }

        ~vlcrender()
        {
            Stop();
        }

        IntPtr imageIntPtr = IntPtr.Zero;

        private void vlc_unlock(IntPtr opaque, IntPtr picture, ref IntPtr planes)
        {
            //Marshal.Release(planes);
        }

        private IntPtr vlc_lock(IntPtr opaque, ref IntPtr planes)
        {
            if (imageIntPtr == IntPtr.Zero)
                imageIntPtr = Marshal.AllocHGlobal(Width * 4 * Height);

            planes = imageIntPtr;
            return imageIntPtr;
        }

        private void vlc_picture(IntPtr opaque, IntPtr picture)
        {
            // TODO: figure out SKColorType conversion
            var image = (Bitmap)new Bitmap(Width, Height, 4 * Width, (System.Drawing.Imaging.PixelFormat)SKColorType.Bgra8888, picture).Clone();

            _onNewImage?.Invoke(this, image);
        }
    }
}
