    using System;
    using System.Security.Permissions;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
    namespace SafeHandleExamples
    {
        class Example
        {
            public static void Main()
            {
    
                IntPtr ptr = Marshal.AllocHGlobal(10);
    
                Console.WriteLine("Ten bytes of unmanaged memory allocated.");
    
                SafeUnmanagedMemoryHandle memHabdle = new SafeUnmanagedMemoryHandle(ptr, true);
    
                if (memHabdle.IsInvalid)
                {
                    Console.WriteLine("SafeUnmanagedMemoryHandle is invalid!.");
                }
                else
                {
                    Console.WriteLine("SafeUnmanagedMemoryHandle class initialized to unmanaged memory.");
                }
    
                Console.ReadLine();
            }
        }
    
    
    
    
        // Demand unmanaged code permission to use this class.
        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        sealed class SafeUnmanagedMemoryHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
    
            // Set ownsHandle to true for the default constructor.
            internal SafeUnmanagedMemoryHandle() : base(true) { }
    
            // Set the handle and set ownsHandle to true.
            internal SafeUnmanagedMemoryHandle(IntPtr preexistingHandle, bool ownsHandle)
                : base(ownsHandle)
            {
                SetHandle(preexistingHandle);
            }
    
            // Perform any specific actions to release the 
            // handle in the ReleaseHandle method.
            // Often, you need to use Pinvoke to make
            // a call into the Win32 API to release the 
            // handle. In this case, however, we can use
            // the Marshal class to release the unmanaged
            // memory.
            override protected bool ReleaseHandle()
            {
                // "handle" is the internal
                // value for the IntPtr handle.
    
                // If the handle was set,
                // free it. Return success.
                if (handle != IntPtr.Zero)
                {
    
                    // Free the handle.
                    Marshal.FreeHGlobal(handle);
    
                    // Set the handle to zero.
                    handle = IntPtr.Zero;
    
                    // Return success.
                    return true;
    
                }
    
                // Return false. 
                return false;
    
            }
        }
    }
