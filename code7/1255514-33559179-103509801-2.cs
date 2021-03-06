    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication6
    {
    	public partial class Form1 : Form
    	{
    		// initialize board of 5x5
    		private int[,] board = new int[5, 5];
    
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void Form1_Load(object sender, EventArgs e)
    		{
    			DrawBoard();
    		}
    
    		private void DrawBoard()
    		{
    			for (var i = 0; i <= board.GetUpperBound(0); i++)
    			{
    				for (var j = 0; j <= board.GetUpperBound(1); j++)
    				{
    					// for name and text
    					var name = string.Format("{0}, {1}", i, j);
    
    					var label = new Label()
    					{
    						Name = name, // name of label
    						Size = new Size(55, 55),
    						BorderStyle = BorderStyle.FixedSingle,
    						Location = new Point(i * 55, j * 55), // location depends on iteration
    						Text = name
    					};
    
    					label.Click += ClickLabel; // subscribe the Click event handler
    
    					pictureBox1.Controls.Add(label); // add label to a container
    				}
    			}
    		}
    
    		// this event handler will handle all the labels click event
    		private void ClickLabel(object sender, EventArgs e)
    		{
    			var label = (Label)sender; // this is the label that you click
    
    			// change the color
    			if (radPlayerBlack.Checked)
    			{
    				// Player White
    				label.BackColor = Color.Black;
    			}
    			else
    			{
    				// Player Black
    				label.BackColor = Color.White;
    			}
    		}
    	}
    }
