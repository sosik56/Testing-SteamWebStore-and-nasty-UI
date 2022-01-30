using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;



class MyForm : Form
{
    ListBox listBox1;

    public MyForm()
    {
        this.Size = new Size(1000,1000);
        PictureBox pictureBox1 = new PictureBox();
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        Bitmap image1 = new Bitmap(@"C:\Users\User\Pictures\Saved Pictures\toxicPrinces.png");
        pictureBox1.Image = (Image)image1;
        pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        this.Controls.Add(pictureBox1);

        Button button1 = new Button();
        button1.Location = new Point(500,850);
        button1.Size = new Size(130, 60);
        button1.Text = "FLIP THE IMAGE!";
        this.Controls.Add(button1);
        button1.Click += new EventHandler(button1_Click);
        this.Text = "BEFORE FLIP";

        //listBox1 = new ListBox();
        //listBox1.Location = new Point(500, 750);
        //listBox1.Size = new Size(100, 100);
        //listBox1.Items.Add("Лес");
        //listBox1.Items.Add("Степь ");
        //listBox1.Items.Add("Озеро");
        //listBox1.Items.Add("Море");
        //listBox1.Items.Add("Океан");
        //listBox1.SelectedIndex = 2;
        //this.Controls.Add(listBox1);       

        void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Вы выбрали " + listBox1.SelectedItem, "Уведомление", MessageBoxButtons.OK);
        }       

    }
    static void Main()
    {
        Application.Run(new MyForm());
    }
    private void InitializeComponent()
    {
        this.SuspendLayout(); 
        // // MyForm //
        this.BackColor = SystemColors.Control; 
        this.ClientSize = new Size(292, 273);
        this.Name = "MyForm"; 
        this.ResumeLayout(false); 
    }

 }
