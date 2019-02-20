using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace tennis
{
    //枚举游戏状态
    public enum GameState
    {
        Close = 1, Open = 2, Pause = 3
    }
    //枚举 球员运动方向
    public enum Directtion
    {
        Up = 1, Down = 2, Left = 3, Right = 4
    }
    //枚举 球员击球动作
    public enum Hit
    {
        Serve = 1, Forehand = 2, Backhand = 3, ShortHit = 4
    }
    //枚举敌我两方
    public enum Side
    {
        Me = 1, Enemy = 2
    }

    class Player
    {
        #region 私有字段
        //球员坐标位置（需要添加System。Drawing命名空间）
        public Point _position = new Point(200, 200);

        //球员运动方向
        private Directtion _direction = Directtion.Up;
        //球员运动步长
        private int _step = 8;
        //球员尺寸大小
        private int _size = 30;
        //敌我方标志
        Side _side;

        //击球动作
        Hit _hit;

        //球员位图数组
        private Bitmap[] _playerBmp = new Bitmap[28];
        //当前球员位图
        private Bitmap _nowPlayerBmp = new Bitmap(80, 80);
        //球员位图轮换标志
        private Boolean _playerBmpChange = true;
        //发球位图轮换标志
        private int _serveBmpChange = 0;
        #endregion
        #region  公有属性
        //球员坐标
        public Point _Position
        {
            get { return _position; }
            set { _position = value; }
        }
        //球员运动方向
        public Directtion _Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        //球员运动步长
        public int _Step
        {
            get { return _step; }
            set { _step = value; }
        }
        //球员尺寸大小
        public int _Size
        {
            get { return _size; }
            set { _size = value; }
        }
        //敌我方标志
        public Side _Side
        {
            get { return _side; }
            set { _side = value; }
        }
        public Hit _Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }
        #endregion

        //类构造方法
        public Player(Side side)
        {
            //保存敌我方标志
            _side = side;
            if (side == Side.Me)
            {
                //装载所有的我方球员位图图片
                _playerBmp[0] = new Bitmap("Images\\up1.gif");
                _playerBmp[1] = new Bitmap("Images\\up2.gif");
                _playerBmp[2] = new Bitmap("Images\\up1.gif");
                _playerBmp[3] = new Bitmap("Images\\up2.gif");
                _playerBmp[4] = new Bitmap("Images\\left1.gif");
                _playerBmp[5] = new Bitmap("Images\\left2.gif");
                _playerBmp[6] = new Bitmap("Images\\right1.gif");
                _playerBmp[7] = new Bitmap("Images\\right2.gif");
                _playerBmp[8] = new Bitmap("Images\\longma_zhanli.gif");
                _playerBmp[9] = new Bitmap("Images\\serve1.png");
                _playerBmp[10] = new Bitmap("Images\\serve2.png");
                _playerBmp[11] = new Bitmap("Images\\serve3.png");
                _playerBmp[12] = new Bitmap("Images\\serve4.png");
                _playerBmp[13] = new Bitmap("Images\\serve5.png");
                _playerBmp[14] = new Bitmap("Images\\forehand1.png");
                _playerBmp[15] = new Bitmap("Images\\forehand2.png");
                _playerBmp[16] = new Bitmap("Images\\forehand3.png");
                _playerBmp[17] = new Bitmap("Images\\forehand4.png");
                _playerBmp[18] = new Bitmap("Images\\forehand5.png");
                _playerBmp[19] = new Bitmap("Images\\backhand1.png");
                _playerBmp[20] = new Bitmap("Images\\backhand2.png");
                _playerBmp[21] = new Bitmap("Images\\backhand3.png");
                _playerBmp[22] = new Bitmap("Images\\backhand4.png");
                _playerBmp[23] = new Bitmap("Images\\backhand5.png");
                _playerBmp[24] = new Bitmap("Images\\shortHit2.png");
                _playerBmp[25] = new Bitmap("Images\\shortHit3.png");
                _playerBmp[26] = new Bitmap("Images\\shortHit4.png");
                _playerBmp[27] = new Bitmap("Images\\shortHit5.png");
                //让我方球员在屏幕正下方生成（添加system.Windows.Forms）
                _position.X = Screen.PrimaryScreen.Bounds.Width / 2 - 130;
                _position.Y = Screen.PrimaryScreen.Bounds.Height - 370;
                //设置为方球员默认的运动方向为上
                _direction = Directtion.Up;
                _nowPlayerBmp = _playerBmp[8];
            }
            else
            {
                //装载所有的对方球员位图图片
                _playerBmp[0] = new Bitmap("Images\\up1.gif");
                _playerBmp[1] = new Bitmap("Images\\up2.gif");
                _playerBmp[2] = new Bitmap("Images\\up1.gif");
                _playerBmp[3] = new Bitmap("Images\\up2.gif");
                _playerBmp[4] = new Bitmap("Images\\enemyLeft1.png");
                _playerBmp[5] = new Bitmap("Images\\enemyLeft2.png");
                _playerBmp[6] = new Bitmap("Images\\enemyRight1.png");
                _playerBmp[7] = new Bitmap("Images\\enemyRight2.png");
                _playerBmp[8] = new Bitmap("Images\\EnemyStand.gif");
                _playerBmp[9] = new Bitmap("Images\\serve1.png");
                _playerBmp[10] = new Bitmap("Images\\serve2.png");
                _playerBmp[11] = new Bitmap("Images\\serve3.png");
                _playerBmp[12] = new Bitmap("Images\\serve4.png");
                _playerBmp[13] = new Bitmap("Images\\serve5.png");
                _playerBmp[14] = new Bitmap("Images\\forehand1.png");
                _playerBmp[15] = new Bitmap("Images\\forehand2.png");
                _playerBmp[16] = new Bitmap("Images\\forehand3.png");
                _playerBmp[17] = new Bitmap("Images\\forehand4.png");
                _playerBmp[18] = new Bitmap("Images\\forehand5.png");
                _playerBmp[19] = new Bitmap("Images\\enemyBackhand1.png");
                _playerBmp[20] = new Bitmap("Images\\enemyBackhand2.png");
                _playerBmp[21] = new Bitmap("Images\\enemyBackhand3.png");
                _playerBmp[22] = new Bitmap("Images\\enemyBackhand4.png");
                _playerBmp[23] = new Bitmap("Images\\enemyBackhand5.png");
                _playerBmp[24] = new Bitmap("Images\\shortHit2.png");
                _playerBmp[25] = new Bitmap("Images\\shortHit3.png");

                //让敌方球员在屏幕正下方生成（添加system.Windows.Forms）
                _position.X = Screen.PrimaryScreen.Bounds.Width / 2 +50;
                _position.Y = Screen.PrimaryScreen.Bounds.Height - 1000;
                //设置为方球员默认的运动方向为上
                _direction = Directtion.Down;
                _nowPlayerBmp = _playerBmp[8];
            }

            //设置球员位图的透明色
            //for (int i = 0; i <= 7; i++)
              //  _playerBmp[i].MakeTransparent(Color.Black);
            //当前球员位图为向上运动的位图
            
        }
        //(方法)球员移动
        public void Move(Directtion direction)
        {
            //保存运动方向
            _direction = direction;

            //如果向上移动
            if (_direction == Directtion.Up)
            {
                //设定球员移动后所在的位置
                _position.Y = _position.Y - _step;
                //设置当前显示的球员位图（为了让效果逼真，需要两幅图切换）
                if (_playerBmpChange == true)
                    _nowPlayerBmp = _playerBmp[0];
                else
                    _nowPlayerBmp = _playerBmp[1];
            }
            //如果向下移动
            if (_direction == Directtion.Down)
            {
                //设定球员移动后所在的位置
                _position.Y = _position.Y + _step;
                //设置当前显示的球员位图（为了让效果逼真，需要两幅图切换）
                if (_playerBmpChange == true)
                    _nowPlayerBmp = _playerBmp[2];
                else
                    _nowPlayerBmp = _playerBmp[3];
            }
            //如果向左移动
            if (_direction == Directtion.Left)
            {
                //设定球员移动后所在的位置
                _position.X = _position.X - _step;
                //设置当前显示的球员位图（为了让效果逼真，需要两幅图切换）
                if (_playerBmpChange == true)
                    _nowPlayerBmp = _playerBmp[4];
                else
                    _nowPlayerBmp = _playerBmp[5];
            }
            //如果向右移动
            if (_direction == Directtion.Right)
            {
                //设定球员移动后所在的位置
                _position.X = _position.X + _step;
                //设置当前显示的球员位图（为了让效果逼真，需要两幅图切换）
                if (_playerBmpChange == true)
                    _nowPlayerBmp = _playerBmp[6];
                else
                    _nowPlayerBmp = _playerBmp[7];
            }
            //切换球员位图轮换标志
            _playerBmpChange = !_playerBmpChange;
        }
        //发球
        public void Action(Hit hit)
        {
            //保存敌我方标志
            _hit = hit;

            //如果发球
            if (hit == Hit.Serve)
            {

                //设置当前显示的球员位图（为了让效果逼真，需要图切换）
                if (_serveBmpChange == 0)
                {
                    _nowPlayerBmp = _playerBmp[9];
                }
                 if (_serveBmpChange == 1)
                    _nowPlayerBmp = _playerBmp[10];
                 if (_serveBmpChange == 2)
                    _nowPlayerBmp = _playerBmp[11];
               if (_serveBmpChange == 3)
                    _nowPlayerBmp = _playerBmp[12];
               if (_serveBmpChange == 4)
                    _nowPlayerBmp = _playerBmp[13];
              
            }
            //如果forehand
            if (hit == Hit.Forehand)
            {
                //设置当前显示的球员位图（为了让效果逼真，需要图切换）
                if (_serveBmpChange == 0)
                {
                    _nowPlayerBmp = _playerBmp[14];
                }
                if (_serveBmpChange == 1)
                    _nowPlayerBmp = _playerBmp[15];
                if (_serveBmpChange == 2)
                    _nowPlayerBmp = _playerBmp[16];
                if (_serveBmpChange == 3)
                    _nowPlayerBmp = _playerBmp[17];
                if (_serveBmpChange == 4)
                    _nowPlayerBmp = _playerBmp[18];
              
            }
            //backhand
            if (hit == Hit.Backhand)
            {

                //设置当前显示的球员位图（为了让效果逼真，需要图切换）
                if (_serveBmpChange == 0)
                {
                    _nowPlayerBmp = _playerBmp[19];
                }
                if (_serveBmpChange == 1)
                    _nowPlayerBmp = _playerBmp[20];
                if (_serveBmpChange == 2)
                    _nowPlayerBmp = _playerBmp[21];
                if (_serveBmpChange == 3)
                    _nowPlayerBmp = _playerBmp[22];
                if (_serveBmpChange == 4)
                    _nowPlayerBmp = _playerBmp[23];

            }
            //shorthit
            if (hit == Hit.ShortHit)
            {

                //设置当前显示的球员位图（为了让效果逼真，需要图切换）
                if (_serveBmpChange == 0)
                {
                    _nowPlayerBmp = _playerBmp[19];
                }
                if (_serveBmpChange == 1)
                    _nowPlayerBmp = _playerBmp[24];
                if (_serveBmpChange == 2)
                    _nowPlayerBmp = _playerBmp[25];
                if (_serveBmpChange == 3)
                    _nowPlayerBmp = _playerBmp[26];
                if (_serveBmpChange == 4)
                    _nowPlayerBmp = _playerBmp[27];

            }
            //切换发球位图轮换标志
            _serveBmpChange = _serveBmpChange + 1;
            if (_serveBmpChange == 5)
            { 
                _serveBmpChange = 0;
            
            }
        }
        //击球运动
        //(方法）球员绘制
        public void DrawMe(Graphics g)
        {
            //绘制球员
            g.DrawImage(_nowPlayerBmp, _position);
        }
    }
}
