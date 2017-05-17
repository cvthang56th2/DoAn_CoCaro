using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro
{
    class BanCo
    {
        #region Khai báo biến, constructer, getter và setter
        private int _SoDong;

        public int SoDong
        {
            get { return _SoDong; }
            set { _SoDong = value; }
        }
        private int _SoCot;

        public int SoCot
        {
            get { return _SoCot; }
            set { _SoCot = value; }
        }
        public BanCo()
        {
            _SoDong = 0;
            _SoCot = 0;
        }
        public BanCo(int soDong, int soCot)
        {
            _SoCot = soCot;
            _SoDong = soDong;
        }
        #endregion

        #region Các phương thức
        public void VeBanCo(Graphics g)
        {
            for (int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(CaroChess.pen, i * OCo._ChieuRong, 0, i * OCo._ChieuRong, _SoDong * OCo._ChieuCao);
            }
            for (int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j * OCo._ChieuCao, _SoCot * OCo._ChieuRong, j * OCo._ChieuCao);
            }
        }
        public void VeQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillEllipse(sb, point.X + 2, point.Y + 2, OCo._ChieuRong - 4, OCo._ChieuCao - 4);
        }
        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillEllipse(sb, point.X + 2, point.Y + 2, OCo._ChieuRong - 4, OCo._ChieuCao - 4);
        }
        #endregion
    }
}
