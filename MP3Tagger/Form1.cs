using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;
namespace MP3TagsEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            OpenFileDialog dialog =  new OpenFileDialog();
            dialog.ShowDialog();
            Program.FILE = dialog.FileName;

            if(Program.FILE.Equals("") || Program.FILE.Equals(" ")) {
                MessageBox.Show("MP3 File not specified");
                return;
            }
            File file = File.Create(Program.FILE);
            if(file.Writeable && file.PossiblyCorrupt) {
                MessageBox.Show("File corrupt or not-writeable");
                return;
            }
            song.Text = Program.FILE;
            album.Text = file.Tag.Album;
            artist.Text = file.Tag.FirstPerformer;
            name.Text = file.Tag.Title;

        }


        private void button3_Click(object sender, EventArgs e) {
       

            if(Program.FILE.Equals("") || Program.FILE.Equals(" ")) {
                MessageBox.Show("MP3 File not specified");
                return;
            }
            File file = File.Create(Program.FILE);
            if(file.Writeable && file.PossiblyCorrupt) {
                MessageBox.Show("File corrupt or not-writeable");
                return;
            }

            file.Tag.Album = album.Text;
            file.Tag.Title = name.Text;
            file.Tag.Artists = new string[] { artist.Text };
            file.Tag.Performers = new string[] { artist.Text };
           
            file.Save();
            string newName = System.IO.Directory.GetParent(Program.FILE) + @"\" + artist.Text + " - " + name.Text + ".mp3";
            System.IO.File.Move(Program.FILE, newName);
            MessageBox.Show("Sucessfully changed tags. ");


            Program.FILE = newName;
            song.Text = Program.FILE;



        }
    }
}
