using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Lytes
{
    public partial class MainForm : Form
    {
        private GameInfo gameInfo;
        private Size tileSize = new Size(50,50);
        private Tile[,] tiles;
        public static Image onImage, offImage;
        private Font normalFont, boldFont;

        private int totalClicks;
        private int par;
        private int numLightsOn;

        private const int MAX_LEVEL = 999;

        public MainForm()
        {
            InitializeComponent();
            loadImages();
            normalFont = this.Font;
            boldFont = new Font(normalFont, FontStyle.Bold);

            gameInfo = new GameInfo(5, 1, 1);
            gameInfo.restore();

            tiles = new Tile[gameInfo.gridSize, gameInfo.gridSize];
            setupGrid();
            gridPanel_SizeChanged(null, null);
            loadGame(gameInfo.currentLevel);
            this.Width = Math.Max(gameInfo.gridSize * onImage.Width, this.Width);
            gridPanel.Refresh();
        }

        /// <summary>
        /// instantiates an array of buttons and places
        /// them inside the central panel.
        /// </summary>
        private void setupGrid() {
            Tile tile;
            int len = tiles.GetLength(0);
            for (int i = 0; i < len; i++) {
                for (int j = 0; j < len; j++) {
                    tile = new Tile();
                    tile.FlatStyle = FlatStyle.Flat;
                    //tile.Image = offImage;
                    tile.Size = this.tileSize;
                    tile.Location = new System.Drawing.Point(j * tileSize.Width, i * tileSize.Width);
                    tile.Name = (5 * i + j).ToString();
                    tile.MouseClick += new MouseEventHandler(handleClick);
                    tiles[i, j] = tile;
                    this.gridPanel.Controls.Add(tile);
                }
            }
        }

        /// <summary>
        /// Loads the on and off Button images.
        /// </summary>
        private static void loadImages() {

            offImage = global::Lytes.Properties.Resources.off;
            onImage = global::Lytes.Properties.Resources.on;
            //System.Reflection.Assembly thisExe;
            //thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            //System.IO.Stream stream = thisExe.GetManifestResourceStream("Lytes.Resources.off.png");
            //offImage = Image.FromStream(stream);
            //stream = thisExe.GetManifestResourceStream("Lytes.Resources.on.png");
            //onImage = Image.FromStream(stream);
        }

        /// <summary>
        /// Resizes the array of tile to match the size
        /// of the containing panel.
        /// </summary>
        private void resizeTiles() {
            Tile tile;
            int len = tiles.GetLength(0);
            for (int i = 0; i < len; i++) {
                for (int j = 0; j < len; j++) {
                    tile = tiles[i, j];
                    tile.Size = this.tileSize;
                    tile.Location = new System.Drawing.Point(j * tileSize.Width, i * tileSize.Width);
                    Point p = tile.Location;
                    p.X = j * tileSize.Width;
                    p.Y = i * tileSize.Width;
                }
            }
        }

        private void loadGame(int levelCode) {
            if (levelCode < 1 || levelCode > MAX_LEVEL) {
                throw new ArgumentOutOfRangeException(
                    "levelCode",
                    levelCode + " is not a valid level number.");
            }

            do {
                loadGameSafe(levelCode);
                levelCode++;
            } while (isEmpty());
        }

        /// <summary>
        /// loads a configuration from a integer code.
        /// </summary>
        /// <param name="levelCode"></param>
        private void loadGameSafe(int levelCode) {

            clear();
            gameInfo.currentLevel = levelCode;
            Random random = new Random(levelCode);

            par = (levelCode / 4) + 1;
            int len = tiles.GetLength(0); ;
            int max = len * len;
            if (par > max) {
                par = max;
            }

            numLightsOn = 0;
            for (int i = 0; i < par; i++) {
                int x = random.Next(len);
                int y = random.Next(len);
                click(x, y);
            }
            totalClicks = 0;
            resetLabels();
            gridPanel.Refresh();
        }

        /// <summary>
        /// handles mouse clicks frome the user.
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        void handleClick(object sender, MouseEventArgs e) {
            int index = Convert.ToInt32(((Button)sender).Name);
            int i = index / 5;
            int j = index % 5;
            click(i, j, true);
        }

        /// <summary>
        /// Clears the tiles and sets all to false;
        /// </summary>
        private void clear() {
            int len = tiles.GetLength(0);
            for (int i = 0; i < len; i++) {
                for (int j = 0; j < len; j++) {
                    tiles[i, j].set(false);
                }
            }
            numLightsOn = 0;
        }

        /// <summary>
        /// Checks if the array of tiles contains any lights turned on.
        /// </summary>
        /// <returns>True if there are no lights turned on,
        /// false otherwise.</returns>
        public bool isEmpty() {
            return this.numLightsOn == 0;
        }

        /// <summary>
        /// Updates the ui lables between clicks and levels.
        /// </summary>
        private void resetLabels() {
            this.parLabel.Text = this.par.ToString();
            this.totalClicksLabel.Text = "0";
            this.totalClicksLabel.ForeColor = Color.Black;
            Font font = totalClicksLabel.Font;
            font = normalFont;
            totalClicksLabel.Font = font;
            this.currentLevelLabel.Text = gameInfo.currentLevel.ToString();
        }

        /// <summary>
        /// Performs a click on the tile specified by
        /// the given coordinates.
        /// </summary>
        /// <param name="i">the vertical coordinate of the tile.</param>
        /// <param name="j">the horizontal coordinate of the tile.</param>
        public void click(int i, int j, bool animate=false) {
            int len = tiles.GetLength(0);
            if (i < len && i >= 0 && j < len && j >= 0) {
                int max = len - 1;
                toggle(i, j, animate);

                // left
                if (j > 0) { toggle(i, j - 1, animate); }

                // right
                if (j < max) { toggle(i, j + 1, animate); }

                // up
                if (i > 0) { toggle(i - 1, j, animate); }

                // down
                if (i < max) { toggle(i + 1, j, animate); }

                this.totalClicks++;
                totalClicksLabel.Text = totalClicks.ToString();

                if (totalClicks > this.par) {
                    totalClicksLabel.ForeColor = Color.Red;
                    Font font = totalClicksLabel.Font;
                    font = boldFont;
                    totalClicksLabel.Font = font;
                }

                if (!animate) {
                    return; // HACK
                }

                // perform animation:
                while (updateTiles()) {
                    this.gridPanel.Refresh();
                }

                // check for win
                if (isEmpty()) {

                    Toast toast = new Toast(string.Format("level {0} completed!", gameInfo.currentLevel));
                    toast.Show();
                    //this.Focus();
                    toast.Location = new Point(
                        Location.X + this.Width/2 - toast.Width/2,
                        Location.Y + this.Height/2 - toast.Height/2);

                    // load the next game
                    if (gameInfo.currentLevel < MAX_LEVEL) {
                        gameInfo.currentLevel++;
                        if (gameInfo.currentLevel > gameInfo.highestLevel) {
                            gameInfo.highestLevel = gameInfo.currentLevel;
                        }
                        loadGame(gameInfo.currentLevel);
                    } else {
                        MessageBox.Show("You beat all of the levels!", "You win!", MessageBoxButtons.OK);
                        loadGame(new Random().Next(MAX_LEVEL));
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// this loop updates the alpha value
        /// of the tiles until the animation is done.
        /// </summary>
        /// <returns></returns>
        private bool updateTiles() {
            bool repaint = false;
            int len = tiles.GetLength(0);
            for (int i = 0; i < len; i++) {
                for (int j = 0; j < len; j++) {
                    repaint = tiles[i, j].updateAlpha() || repaint;
                }
            }
            return repaint;
        }

        private void toggle(int i, int j, bool animate) {
            tiles[i, j].toggle(animate);
            this.numLightsOn += (tiles[i, j].state) ? 1 : -1;
        }

        private void resetButton_MouseClick(object sender, MouseEventArgs e) {
            loadGame(gameInfo.currentLevel);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            gameInfo.save();
        }

        /// <summary>
        /// Loads a specific game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGameMenuItem_Click(object sender, EventArgs e) {
            InputDialog input = new InputDialog();
            input.maxLevel = gameInfo.highestLevel.ToString();
            DialogResult result = input.ShowDialog(this);
            if (result == DialogResult.OK) {
                try {
                    loadGame(Convert.ToInt32(input.InputText));
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "oops!", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Quits the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitMenuItem_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        /// <summary>
        /// Starts a new game from level 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameMenuItem_Click(object sender, EventArgs e) {
            loadGame(1);
        }

        /// <summary>
        /// handles resize events for the panel that holds the button array.
        /// the new button size is calculated, and resizeButtons() is called.
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void gridPanel_SizeChanged(object sender, EventArgs e) {
            int buttonLength = Math.Min(gridPanel.Height, gridPanel.Width) / tiles.GetLength(0);
            tileSize.Height = buttonLength;
            tileSize.Width = buttonLength;
            resizeTiles();
        }

    }

    internal class Tile : Button
    {
        internal int alpha;  // TODO: use for animation
        private const int DT = 25;
        internal Boolean state;

        internal static ColorMatrix colorMatrix = new ColorMatrix();
        internal static ImageAttributes imageAttributes = new ImageAttributes();

        public Tile() {
            this.BackColor = Color.Black;
            this.BackgroundImage = MainForm.offImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            alpha = 0;
            state = false;
            colorMatrix.Matrix33 = 0.0f;
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        }

        /// <summary>
        /// sets the state of this tile.
        /// </summary>
        /// <param name="state"></param>
        public void set(bool state) {
            this.state = state;
            alpha = (state) ? 255 : 0;
        }

        /// <summary>
        /// toggles the state of this tile
        /// </summary>
        /// <param name="animate">true if the animation process
        /// should be started</param>
        public void toggle(bool animate) {
            state = !state;
            if (animate) {
                alpha += (state) ? DT : -DT;
            } else {
                alpha = (state) ? 255 : 0;
            }
        }

        /// <summary>
        /// updates the alpha value of this tile by
        /// the appropriate amount.
        /// </summary>
        /// <returns>true if this tile is not done animating</returns>
        public bool updateAlpha() {

            if (this.state) {
                if (this.alpha < 255) {
                    alpha += DT;
                    return true;
                }

                if (alpha > 255) {
                    alpha = 255;
                }
                return false;
            } else {
                if (this.alpha > 0) {
                    alpha -= DT;
                    return true;
                }
                
                if (alpha < 0) {
                    alpha = 0;
                }
                return false;
            }
        }

        /// <summary>
        /// paints the tile
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            //MessageBox.Show(string.Format("state: {0}, alpha: {1}, name: {2}",state,alpha,Name));
            colorMatrix.Matrix33 = alpha/255f;
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Rectangle dstRect = new Rectangle(0, 0, this.Width, this.Height);
            g.DrawImage(
                MainForm.onImage,
                dstRect,
                0,
                0,
                MainForm.onImage.Width,
                MainForm.onImage.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
        }
    }
}
