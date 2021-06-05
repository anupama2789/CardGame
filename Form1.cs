using System;
using System.Drawing;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        #region variables
        private PictureBox[] pictures;
        public const string imagepath = @"NewCards/";
        string[] cards = new string[]{
            "ClubAce", "DiamondAce","HeartAce" ,"SpadeAce",
            "ClubTwo","DiamondTwo","HeartTwo","SpadeTwo",
            "ClubThree","DiamondThree","HeartThree","SpadeThree",
            "ClubFour", "DiamondFour", "HeartFour", "SpadeFour",
            "ClubFive", "DiamondFive", "HeartFive", "SpadeFive",
            "ClubSix", "DiamondSix", "HeartSix",  "SpadeSix",
            "ClubSeven", "DiamondSeven", "HeartSeven", "SpadeSeven",
            "ClubEight", "DiamondEight", "HeartEight", "SpadeEight",
            "ClubNine", "DiamondNine", "HeartNine", "SpadeNine",
            "ClubTen", "DiamondTen", "HeartTen", "SpadeTen",
            "ClubJack", "DiamondJack", "HeartJack","SpadeJack",
            "ClubQueen", "DiamondQueen", "HeartQueen", "SpadeQueen",
            "ClubKing","DiamondKing", "HeartKing", "SpadeKing"
        };
        int ArrangeClicked ;
        private PictureBox[] blackbox ;
        private PictureBox[] redbox;
        private PictureBox[] spadebox;
        private PictureBox[] clubbox;
        private PictureBox[] heartbox;
        private PictureBox[] diamondbox;
        private PictureBox[] Onesbox;
        private PictureBox[] Twosbox;
        private PictureBox[] Threesbox;
        private PictureBox[] Foursbox;
        private PictureBox[] Fivesbox;
        private PictureBox[] Sixsbox;
        private PictureBox[] Sevensbox;
        private PictureBox[] Eightsbox;
        private PictureBox[] Ninesbox;
        private PictureBox[] Tensbox;
        private PictureBox[] Jacksbox;
        private PictureBox[] Kingsbox;
        private PictureBox[] Queensbox;
        #endregion
        #region shuffleanddeal
        public Form1()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            pictures = new PictureBox[52];
        }
       
        private void btnShuffle_Click(object sender, EventArgs e)
        {
          
            Shuffle();
            DisplayControls();
        }

  
        private void btnDeal_Click(object sender, EventArgs e)
        {
            Shuffle();
            Deal();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            CreateControls();
            DisplayControls();
        }

        public void CreateControls()
        {
            if (pictures[0] != null)
            {
                DisposeControls();
            }
            for (int i = 0; i <= 51; i++)
            {
                var newPictureBox = new PictureBox();

                newPictureBox.Width = 180;
                newPictureBox.Height = 280;
                pictures[i] = SizeImage(newPictureBox, i);
            }
        }
        public PictureBox SizeImage(PictureBox pb, int i)
        {
            Image image = Image.FromFile(imagepath + cards[i] + ".png");
            pb.Image = image;
            pb.SizeMode = PictureBoxSizeMode.CenterImage;

            return pb;
        }

        public void DisplayControls()
        {
            for (var i = 51; i >= 0; i--)
            {
                pictures[i].Left = (i * 33);// + 100;
                                            //pictures[i].Top = 5;
                                            // this.Controls.Add(pictures[i]);
                this.Controls.Add(pictures[i]);

                //form.Controls.Add(pictures[0]);
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (var i = 0; i < 500; i++)
            {
                int firstcard = random.Next(0, 52);
                int secondcard = random.Next(0, 52);
                if (firstcard != secondcard)
                {
                    var temp = pictures[firstcard];
                    pictures[firstcard] = pictures[secondcard];
                    pictures[secondcard] = temp;
                }

            }
        }
        public void Deal()
        {
            Random random = new Random();

            int firstcard = random.Next(0, 52);
            DisposeControls();
            var newPictureBox = new PictureBox();

            newPictureBox.Width = 180;
            newPictureBox.Height = 280;
            pictures[0] = SizeImage(newPictureBox, firstcard);
            this.Controls.Add(pictures[0]);
            //form.Controls.Add(pictures[0]);
            //pictures.Controls.Add();
        }
        public void DisposeControls()
        {
            foreach (var c in pictures)
            {
                c.Dispose();
            }      
        }
        #endregion

        #region arrange

        #endregion
    }
}
