using System;
using System.Runtime.InteropServices;
//by picrap
//on https://stackoverflow.com/questions/22148849/how-to-get-file-information-using-mono-on-linux
//answered Aug 8 '14 at 15:28

//"...you just need to open the file using Syscall.open,
// use FileProvider.ioctl with the given file descriptor
// and either EXT2_IOC_GETFLAGS or EXT2_IOC_SETFLAGS
// (you'll probably need to change some permissions too,
// this is a raw copy/paste) the way you want
// and then use Syscall.close"

namespace Application
{
    partial class FileProvider
    {
        private const uint IOCPARM_MASK = 0x7f; /* parameters must be < 128 bytes */
        private const uint IOC_VOID = 0x20000000; /* no parameters */
        private const uint IOC_IN = 0x40000000; /* copy out parameters */
        private const uint IOC_OUT = 0x80000000; /* copy in parameters */
        private const uint IOC_INOUT = (IOC_IN | IOC_OUT);
        /* the 0x20000000 is so we can distinguish new ioctl's from old */

        private static uint _IOXXX(uint ioc, int x, int y, int l)
        {
            return ioc | (((uint)l & IOCPARM_MASK) << 16) | ((uint)x << 8) | (uint)y;
        }

        private static uint _IO(int x, int y)
        {
            return _IOXXX(IOC_VOID, x, y, 0);
        }

        private static int SizeOf<T>()
        {
            var type = typeof(T);
            if (type.IsEnum)
                return Marshal.SizeOf(type.GetEnumUnderlyingType());
            return Marshal.SizeOf(type);
        }

        private static uint _IOR<T>(int x, int y)
        {
            return _IOXXX(IOC_OUT, x, y, SizeOf<T>());
        }

        private static uint _IOW<T>(int x, int y)
        {
            return _IOXXX(IOC_IN, x, y, SizeOf<T>());
        }

        private static uint _IORW<T>(int x, int y)
        {
            return _IOXXX(IOC_INOUT, x, y, SizeOf<T>());
        }

        public static uint EXT2_IOC_GETFLAGS
        {
            get { return _IOR<IOC_FLAGS>('f', 1); }
        }

        public static uint EXT2_IOC_SETFLAGS
        {
            get { return _IOW<IOC_FLAGS>('f', 2); }
        }

        [Flags]
        private enum IOC_FLAGS : long
        {
            EXT2_SECRM_FL = 0x00000001, /* Secure deletion */
            EXT2_UNRM_FL = 0x00000002, /* Undelete */
            EXT2_COMPR_FL = 0x00000004, /* Compress file */
            EXT2_SYNC_FL = 0x00000008, /* Synchronous updates */
            EXT2_IMMUTABLE_FL = 0x00000010, /* Immutable file */
            EXT2_APPEND_FL = 0x00000020, /* writes to file may only append */
            EXT2_NODUMP_FL = 0x00000040, /* do not dump file */
            EXT2_NOATIME_FL = 0x00000080, /* do not update atime */
                                          /* Reserved for compression usage... */
            EXT2_DIRTY_FL = 0x00000100,
            EXT2_COMPRBLK_FL = 0x00000200, /* One or more compressed clusters */
            EXT2_NOCOMPR_FL = 0x00000400, /* Access raw compressed data */
            EXT2_ECOMPR_FL = 0x00000800, /* Compression error */
                                         /* End compression flags --- maybe not all used */
            EXT2_BTREE_FL = 0x00001000, /* btree format dir */
            EXT2_INDEX_FL = 0x00001000, /* hash-indexed directory */
            EXT2_IMAGIC_FL = 0x00002000,
            EXT3_JOURNAL_DATA_FL = 0x00004000, /* file data should be journaled */
            EXT2_NOTAIL_FL = 0x00008000, /* file tail should not be merged */
            EXT2_DIRSYNC_FL = 0x00010000, /* Synchronous directory modifications */
            EXT2_TOPDIR_FL = 0x00020000, /* Top of directory hierarchies*/
            EXT4_HUGE_FILE_FL = 0x00040000, /* Set to each huge file */
            EXT4_EXTENTS_FL = 0x00080000, /* Inode uses extents */
            EXT4_EA_INODE_FL = 0x00200000, /* Inode used for large EA */
                                           /* EXT4_EOFBLOCKS_FL 0x00400000 was here */
            FS_NOCOW_FL = 0x00800000, /* Do not cow file */
            EXT4_SNAPFILE_FL = 0x01000000, /* Inode is a snapshot */
            EXT4_SNAPFILE_DELETED_FL = 0x04000000, /* Snapshot is being deleted */
            EXT4_SNAPFILE_SHRUNK_FL = 0x08000000, /* Snapshot shrink has completed */
            EXT2_RESERVED_FL = 0x80000000, /* reserved for ext2 lib */
        }

        [DllImport("libc", EntryPoint = "ioctl", SetLastError = true)]
        private extern static int ioctl(int fd, uint request, ref IOC_FLAGS data);
    }
}
