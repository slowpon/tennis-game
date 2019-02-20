using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace tennis
{
    //枚举球速
    public enum BallSpeed
    {
        LowSpeed = 1, HightSpeed = 2
    }
    public enum BallDirecttion
    {
        Up = 1, Down = 2
    }
    //球位图
  
    class Ball
    {
        //球坐标位置
        private Point _position = new Point(250, 250);
        private Bitmap[] _ballBmp = new Bitmap[2];
        //当前球位图
        private Bitmap _nowBallBmp = new Bitmap(80, 80);
        //
        private Directtion _direction=Directtion.Up;
        //球位图轮换标志
        private Boolean _ballBmpChange = true;
        private Hit _hit;
        //敌我方标志
        private Side _side;
        //类构造方法
        Player _myPlayer = new Player(Side.Me);
        Player _myEnemy = new Player(Side.Enemy);
        public Point _Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Ball()
        {

            
            //装球图片
            _ballBmp[0] = new Bitmap("Images\\ball1.png");
            _ballBmp[1] = new Bitmap("Images\\ball2.png");
            //让方球在屏幕正下方生成（添加system.Windows.Forms）
            _position.X = Screen.PrimaryScreen.Bounds.Width / 2 - 140;
            _position.Y = Screen.PrimaryScreen.Bounds.Height - 420;
            //当前球图片
            _nowBallBmp = _ballBmp[1];
        }

        //方法 球移动
        Random myRand = new Random(DateTime.Now.Second);
        //对方球员
      // Player enemyBall= new Player(Side.Me);
        int x = 10;
        public void Move(Directtion direction,Hit hit)
        {

           // enemyBall._Position = new Point(_position.X + 8, _position.Y - 15);
            //保存击球方向
            _direction = direction;
            //保存击球方式
            _hit = hit;
            //产生一个随机系数随机发球落点（1-2）
            int a = myRand.Next(-4, 4);
            
            //发球控制
            if (_direction == Directtion.Up && _hit == Hit.Serve)
            {
              
                //触底反弹
                //产生一个随机系数随机发球落点（1-2）
                int x = -220;
                int b = myRand.Next(Screen.PrimaryScreen.Bounds.Height/2-230, Screen.PrimaryScreen.Bounds.Height/2- 130);
                if (_position.Y >b)
                {
                    _position.Y = _position.Y +((int)Math.Sqrt(180000-x* x) - (int)Math.Sqrt(180000 - (x+30) * (30+x)))+1; 
                    x = x +8;
                    _position.X = _position.X + 4;
                }
                if (_position.Y < b)
                {//触地
                    _position.Y = _position.Y + ((int)Math.Sqrt(200000 - x * x) - (int)Math.Sqrt(200000 - (x + 20) * (20 + x)));
                    x = x + 2;
                    _position.X = _position.X + 3;

                }
            }
            //电脑回球 
            if (_direction == Directtion.Down)
            {
                    _position.Y = _position.Y +6;
                    _position.X = _position.X - 1;
            }
            //电脑回球
            //if (_direction == Directtion.Up&& _hit == Hit.Backhand)
            //{

            //        _position.Y = _position.Y - 5;
            //        _position.X = _position.X - 2;

            //}
            //玩家回球
            if (_direction == Directtion.Up && _hit == Hit.Forehand)
            {

                int x = -220;
                int b = myRand.Next(Screen.PrimaryScreen.Bounds.Height / 2 - 230, Screen.PrimaryScreen.Bounds.Height / 2 - 130);
                if (_position.Y > b)
                {
                    _position.Y = _position.Y +2+ ((int)Math.Sqrt(180000 - x * x) - (int)Math.Sqrt(180000 - (x + 30) * (30 + x)));
                    x = x + 8;
                    _position.X = _position.X - 3;
                }
                if (_position.Y < b)
                {//触地
                    _position.Y = _position.Y + 2+((int)Math.Sqrt(200000 - x * x) - (int)Math.Sqrt(200000 - (x + 20) * (20 + x)));
                    x = x + 2;
                    _position.X = _position.X - 3;

                }
                
            }
            //必杀技
            if (_direction == Directtion.Up && _hit == Hit.ShortHit)
            {
                if(_position.Y> Screen.PrimaryScreen.Bounds.Height/2-200)
                {
                    _position.Y = _position.Y - 12;
                    _position.X = _position.X - 14;
                }
                else
                {
                    _position.Y = _position.Y - 12;
                    _position.X = _position.X + 14;
                }
            }
        }
        //球旋转
        public void Spin()
        {
            if (_ballBmpChange == true)
                _nowBallBmp = _ballBmp[0];
            else
                _nowBallBmp = _ballBmp[1];
        
            //切换坦克位图轮换标志
            _ballBmpChange = !_ballBmpChange;
        }
        //绘制
        public void DrawMe(Graphics g)
        {

            g.DrawImage(_nowBallBmp, _position);
        }
    }
    
}
