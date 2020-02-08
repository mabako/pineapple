using System;
using System.IO;

namespace Pineapple.IntegrationTests.TestFixtures
{
    /// <summary>
    /// A temporary test directory.
    /// </summary>
    internal sealed class TestDirectory : IDisposable
    {
        /// <summary>
        /// Root path to store files under.
        /// </summary>
        private static readonly string RootPath = Path.Combine(Path.GetTempPath(), "pineapple_tmp");

        /// <summary>
        /// Lock to modify <see cref="RootPath"/>.
        /// </summary>
        private static readonly object RootPathLock = new object();

        static TestDirectory()
        {
            if (Directory.Exists(RootPath))
                DeleteTestRoot();
        }

        /// <summary>
        /// Creates a new <see cref="TestDirectory"/> with a random path.
        /// </summary>
        public TestDirectory()
        {
            FullPath = Path.Combine(RootPath, Guid.NewGuid().ToString());

            // ensure no other process deletes the root path while we try to create a directory inside
            lock (RootPathLock)
            {
                Directory.CreateDirectory(FullPath);
            }
        }

        /// <summary>
        /// Full path to the test directory.
        /// </summary>
        public string FullPath { get; }

        /// <summary>
        /// Deletes the test directory.
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(FullPath, true);

            // if at all possible, delete the test root.
            DeleteTestRoot();
        }

        private static void DeleteTestRoot()
        {
            lock (RootPathLock)
            {
                try
                {
                    Directory.Delete(RootPath);
                }
                catch (IOException)
                {
                    // can't do much about it...
                }
            }
        }
    }
}
