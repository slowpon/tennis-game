using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tennis;
using System.Runtime.InteropServices;

namespace tennis
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        #region 私有字段
        //游戏状态
        private GameState _gameState = GameState.Close;
        //我方球员
        private Player _myPlayer = new Player(Side.Me);
        //对方球员
        private Player _myEnemy = new Player(Side.Enemy);
        //球
        private Ball _myBall = new Ball();
        //动作
        private Hit _playerHit = Hit.Serve;
        private Directtion _direction = Directtion.Up;
        private Point _position;

        #endregion
        //导入动态链接库
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetAsynKeyState(int keyCode);
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //绘制网球场
        public void DrawBoard(Graphics g)
        {


            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //画球场边缘
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 230, screenHeight / 2 - 400), new Point(screenWidth / 2 + 230, screenHeight / 2 - 400));
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 250, screenHeight / 2 + 200), new Point(screenWidth / 2 + 250, screenHeight / 2 + 200));
            //g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 250, 700), new Point(screenWidth / 2 + 250, 700));

            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 + 230, screenHeight / 2 - 400), new Point(screenWidth / 2 + 250, screenHeight / 2 + 200));
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 230, screenHeight / 2 - 400), new Point(screenWidth / 2 - 250, screenHeight / 2 + 200));

            //中线
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 240, screenHeight / 2 - 100), new Point(screenWidth / 2 + 240, screenHeight / 2 - 100));
            //发球线
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 240, screenHeight / 2 - 250), new Point(screenWidth / 2 + 240, screenHeight / 2 - 250));
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2 - 240, screenHeight / 2 + 40), new Point(screenWidth / 2 + 240, screenHeight / 2 + 40));
            //竖线
            g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2, screenHeight / 2 - 250), new Point(screenWidth / 2, screenHeight / 2 + 40));
            //绘制人物
            //  g.DrawImage(playerBmp, new Rectangle(50, 50,650, 700), new Rectangle(150, 30, 605, 700), GraphicsUnit.Pixel);


            //g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2, screenHeight / 2), new Point(screenWidth / 2 + 100, screenHeight / 2));

           // g.DrawLine(new Pen(Color.White, 4), new Point(screenWidth / 2, 400), new Point(screenWidth / 2 + 500,900));

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {



        }





        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.A: { pictureBox1.Left -= 14; pictureBox1.Image = Image.FromFile("zuopao.png");  } break;
            //    case Keys.D: { pictureBox1.Left += 14; pictureBox1.Image = Image.FromFile("youpao.png"); } break;
            //    case Keys.W: { pictureBox1.Top -= 14; pictureBox1.Image = Image.FromFile("qianjin.png"); } break;
            //    case Keys.S: { pictureBox1.Top += 14;  pictureBox1.Image = Image.FromFile("qianjin.png"); } break;
            //    case Keys.B: {  pictureBox1.Image = Image.FromFile("faqiu.gif"); dongzuo_huifu.Enabled = true;
            //                 ball.Enabled = true;
            //        } break;
            //    case Keys.N: { pictureBox1.Image = Image.FromFile("zuojiqiu.gif"); dongzuo_huifu.Enabled = true;

            //        } break;
            //    case Keys.M: { pictureBox1.Image = Image.FromFile("youjiqiu.gif"); dongzuo_huifu.Enabled = true; } break;
            //};

            //如果游戏开始
            if (_gameState == GameState.Open)
            {
                //根据用户按键移动
                if (e.KeyCode == Keys.Up)
                    _myPlayer.Move(Directtion.Up);
                if (e.KeyCode == Keys.Down)
                    _myPlayer.Move(Directtion.Down);
                if (e.KeyCode == Keys.Left)
                    _myPlayer.Move(Directtion.Left);
                if (e.KeyCode == Keys.Right)
                    _myPlayer.Move(Directtion.Right);

                //发球

                if (e.KeyCode == Keys.Z)
                {
                    _myPlayer.Action(Hit.Serve);

                    _playerHit = Hit.Serve;
                    actionControl.Enabled = true;
                    ballSpin.Enabled = true;
                    ballMove.Enabled = true;
                }

                //正手

                if (e.KeyCode == Keys.V)
                {
                    _myPlayer.Action(Hit.Forehand);
                    _playerHit = Hit.Forehand;
                    actionControl.Enabled = true;
                    if (Math.Abs(_myBall._Position.Y - _myPlayer._Position.Y) 
                        < 100 && Math.Abs(_myBall._Position.X - _myPlayer._Position.X) < 100)
                    {
                        ballMove2.Enabled = false;
                        ballMove.Enabled = true;
                    }
                }
                //反手
                if (_gameState == GameState.Open)
                {
                    if (e.KeyCode == Keys.C)
                    {
                        _myPlayer.Action(Hit.Backhand);
                        _playerHit = Hit.Backhand;
                        actionControl.Enabled = true;
                        if (Math.Abs(_myBall._Position.Y - _myPlayer._Position.Y) 
                            < 100 && Math.Abs(_myBall._Position.X - _myPlayer._Position.X) < 100)
                        {
                            ballMove2.Enabled = false;
                            ballMove.Enabled = true;
                        }
                    }
                }
                //小球
                if (e.KeyCode == Keys.X)
                {
                    _myPlayer.Action(Hit.ShortHit);
                    _playerHit = Hit.ShortHit;
                    actionControl.Enabled = true;
                    if (Math.Abs(_myBall._Position.Y - _myPlayer._Position.Y) < 100 &&
                        Math.Abs(_myBall._Position.X - _myPlayer._Position.X) < 100)
                    {
                        ballMove2.Enabled = false;
                        ballMove.Enabled = true;
                    }
                }
            }

            //强制刷新picturebox1
            pictureBox1.Invalidate();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //绘制网球场
            DrawBoard(e.Graphics);
            //绘制我方
            _myPlayer.DrawMe(e.Graphics);
            //绘制对方
            _myEnemy.DrawMe(e.Graphics);
            //绘制球
            _myBall.DrawMe(e.Graphics);
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //开始游戏
            _gameState = GameState.Open;
        }

        private void EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // jiehse游戏
            _gameState = GameState.Close;
        }

        public static int serveControl = 0;
        private void actionControl_Tick(object sender, EventArgs e)
        {
            //serve
            if (_playerHit == Hit.Serve)
            {

                _myPlayer.Action(Hit.Serve);

            }
            //forehand
            if (_playerHit == Hit.Forehand)
            {
                _myPlayer.Action(Hit.Forehand);
                _direction = Directtion.Up;
            }
            //backk
            if (_playerHit == Hit.Backhand)
            {
                _myPlayer.Action(Hit.Backhand);
                _direction = Directtion.Up;
            }
            //shorthit
            if (_playerHit == Hit.ShortHit)
            {
                _myPlayer.Action(Hit.ShortHit);
                _direction = Directtion.Up;
            }

            //次数控制器
            if (serveControl == 4)
            {
                actionControl.Enabled = false;
                serveControl = 0;
            }
            serveControl = serveControl + 1;
            pictureBox1.Invalidate();
        }

        private void ballSpin_Tick(object sender, EventArgs e)
        {
            _myBall.Spin();
            pictureBox1.Invalidate();
        }
        private void ballMove4_Tick(object sender, EventArgs e)
        {

        }
        int x = 5;
        //敌方击球变向
        //控制击球向上
        bool enemyChange = true;
        //控制球往下
        private void ballMove3_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(_myBall._Position.Y - _myEnemy._Position.Y) < 10 && Math.Abs(_myBall._Position.X - _myEnemy._Position.X) < 15)
            {
                _myBall.Move(Directtion.Up, Hit.Forehand);
                enemyActionControl.Enabled = true;
                ballMove3.Enabled = false;
                ballMove2.Enabled = true;
            }
        }
        
        private void ballMove2_Tick(object sender, EventArgs e)
        {
            if (!enemyChange)
            {

                _myBall.Move(Directtion.Down, Hit.Backhand);
            }
            else
            {
                _myBall._Position = new Point(_myBall._Position.X + 1, _myBall._Position.Y + 4);
            }

            // 敌方跟踪球
            if (_myBall._Position.X < _myEnemy._Position.X)
            {
                _myEnemy.Move(Directtion.Left);
            }
            else if (_myBall._Position.X > _myEnemy._Position.X)
            {
                _myEnemy.Move(Directtion.Right);
            }
        }
        private void ballMove_Tick(object sender, EventArgs e)
        {
            Ball myBall = new Ball();
            //发球运动
            if ((_playerHit == Hit.Serve || _playerHit == Hit.Backhand) && _direction == Directtion.Up)
            {
                _myBall.Move(Directtion.Up, Hit.Serve);
            }
            if (_playerHit == Hit.Forehand && _direction == Directtion.Up)
            {
                _myBall.Move(Directtion.Up, Hit.Forehand);
            }
            if (_playerHit == Hit.ShortHit && _direction == Directtion.Up)
            {
                _myBall.Move(Directtion.Up, Hit.ShortHit);
            }
            //if (_myBall._Position.Y < 100)
            //{
            //    ballMove2.Enabled = true;
            //    ballMove.Enabled = false;
            //}

            //若对方在球一定范围内，打开动作控制器
            if (Math.Abs(_myBall._Position.Y - _myEnemy._Position.Y) < 10 && Math.Abs(_myBall._Position.X - _myEnemy._Position.X) < 15)
            {
                _playerHit = Hit.Backhand;
                _direction = Directtion.Down;
                enemyActionControl.Enabled = true;
                ballMove2.Enabled = true;
                ballMove.Enabled = false;
                enemyChange = !enemyChange;
            }
            //若玩家在球一定范围击球，则控制球向上
            //if (Math.Abs(_myBall._Position.Y - _myPlayer._Position.Y) < 30 && Math.Abs(_myBall._Position.X - _myPlayer._Position.X) < 30)
            //{
            //    _playerHit = Hit.Backhand;
            //    _playerHit = Hit.Backhand;
            //    _direction = Directtion.Up;
            //    ballMove3.Enabled = true;
            //    ballMove.Enabled = false;

            //}

            //敌方跟踪球
            if (_myBall._Position.X < _myEnemy._Position.X)
            {
                _myEnemy.Move(Directtion.Left);
            }
            else if (_myBall._Position.X > _myEnemy._Position.X)
            {
                _myEnemy.Move(Directtion.Right);
            }
            //x = x + 5;
            ////敌方追球击球
            //if (_myBall._Position.X< _myEnemy._Position.X)
            //{
            //    _myEnemy.Move(Directtion.Left);

            //    if (Math.Abs(_myBall._Position.Y - _myEnemy._Position.Y) < 50&& Math.Abs(_myBall._Position.X - _myEnemy._Position.X)<50)
            //    {

            //        _playerHit = Hit.Backhand;
            //        enemyActionControl.Enabled = true;
            //        _myBall.Move(Directtion.Down, Hit.Ba);
            //        //_myEnemy._Position = new Point(_myEnemy._Position.X, _myEnemy._Position.Y);
            //    };
            //}
            //else if (_myBall._Position.X > _myEnemy._Position.X)
            //{
            //    _myEnemy.Move(Directtion.Right);
            //}
            //_myEnemy.Move(Directtion.Down);
            pictureBox1.Invalidate();
        }

        private void enemyActionControl_Tick(object sender, EventArgs e)
        {

            //forehand
            if (_playerHit == Hit.Forehand)
            {
                _myEnemy.Action(Hit.Forehand);

            }
            //backk
            if (_playerHit == Hit.Backhand)
            {
                _myEnemy.Action(Hit.Backhand);

            }

            //次数控制器
            if (serveControl == 4)
            {
                enemyActionControl.Enabled = false;
                serveControl = 0;
            }
            serveControl = serveControl + 1;
            pictureBox1.Invalidate();
        }

        private void collisionDetection_Tick(object sender, EventArgs e)
        {

        }
        //出界检测器
        int score1 = 0;
        int score2 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (_myBall._Position.Y< 20)
            {

                score1 = score1 + 1;
                label2.Text = Convert.ToString(score1);
                _myBall._Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 140, Screen.PrimaryScreen.Bounds.Height - 420);
                _myEnemy._Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 + 50, Screen.PrimaryScreen.Bounds.Height - 1000);
                _myPlayer._Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 130, Screen.PrimaryScreen.Bounds.Height - 370);
                ballMove.Enabled = false;
                if (score1 > 4)
                {
                    MessageBox.Show("恭喜你获得胜利");
                    timer1.Enabled = false;
                }
            }
            if (_myBall._Position.Y > 900)
            {
                score2 = score2 + 1;
                label3.Text = Convert.ToString(score2);
                _myBall._Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 140, Screen.PrimaryScreen.Bounds.Height - 420);
                _myEnemy._Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 + 50, Screen.PrimaryScreen.Bounds.Height - 1000);
                _myPlayer._Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 130, Screen.PrimaryScreen.Bounds.Height - 370);
                ballMove2.Enabled = false;
                _playerHit = Hit.Serve;
               
            }

            
            //    if (_gameState==GameState.Open)
            //    { 
            //        bool keyDown = (((ushort)GetAsynKeyState((int)Keys.Down)) & 0xffff) != 0;
            //        if (keyDown == true)
            //            _myPlayer.Move(Directtion.Down);
            //        bool keyUp = (((ushort)GetAsynKeyState((int)Keys.Up)) & 0xffff) != 0;
            //        if (keyUp == true)
            //            _myPlayer.Move(Directtion.Up);
            //        bool keyLeft = (((ushort)GetAsynKeyState((int)Keys.Left)) & 0xffff) != 0;
            //        if (keyLeft == true)
            //            _myPlayer.Move(Directtion.Left);
            //        bool keyRight = (((ushort)GetAsynKeyState((int)Keys.Right)) & 0xffff) != 0;
            //        if (keyLeft == true)
            //            _myPlayer.Move(Directtion.Right);
            //        pictureBox1.Invalidate();
            //    }
            //}
        }
    }
}
