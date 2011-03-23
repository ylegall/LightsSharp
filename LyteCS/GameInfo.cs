using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

namespace Lytes
{
    /// <summary>
    /// Holds game information that needs to be persisted.
    /// </summary>
    struct GameInfo
    {
        internal int gridSize;
        internal int currentLevel;
        internal int highestLevel;

        public GameInfo(int gridSize, int currentLevel, int highestLevel) {
            this.gridSize = gridSize;
            this.currentLevel = currentLevel;
            this.highestLevel = highestLevel;
        }

        /// <summary>
        /// Saves game data to a file.
        /// Saves the current level, highest level and grid size.
        /// </summary>
        internal void save() {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAssembly();
            StreamWriter writer = null;
            try {
                Stream stream = new IsolatedStorageFileStream("Lytes.config", FileMode.Create, FileAccess.Write, file);
                writer = new StreamWriter(stream);
                writer.WriteLine(gridSize);
                writer.WriteLine(currentLevel);
                writer.WriteLine(highestLevel);
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message, "error", System.Windows.Forms.MessageBoxButtons.OKCancel);
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// Restores game data by reading a file.
        /// </summary>
        internal void restore() {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAssembly();
            StreamReader reader = null;
            try {
                Stream stream = new IsolatedStorageFileStream("Lytes.config", FileMode.Open, FileAccess.Read, file);
                reader = new StreamReader(stream);
                gridSize = Convert.ToInt32(reader.ReadLine());
                currentLevel = Convert.ToInt32(reader.ReadLine());
                highestLevel = Convert.ToInt32(reader.ReadLine());
            } catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message, "error", System.Windows.Forms.MessageBoxButtons.OKCancel);
            } finally {
                if (reader != null) {
                    reader.Close();
                }
            }
        }
    }
}
