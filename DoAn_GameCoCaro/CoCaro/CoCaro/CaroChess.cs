using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro
{
    public enum KETTHUC
    {
        HoaCo,
        Player,
        Player1,
        Player2,
        Com
    }
    class CaroChess
    {
        #region Khai báo biến, constructer, getter và setter
        public static Pen pen;
        public static SolidBrush sbBG;
        
        private OCo[,] _MangOCo;
        private BanCo _BanCo;
        
        private Stack<OCo> stack_CacNuocDaDi;
        private Stack<OCo> stack_CacNuocUndo;

        private int _LuotDi;

        public int LuotDi
        {
            get { return _LuotDi; }
            set { _LuotDi = value; }
        }
        private int _CheDoChoi;
        private bool _SanSang;

        private KETTHUC _KetThuc;

        public int CheDoChoi
        {
            get { return _CheDoChoi; }
            set { _CheDoChoi = value; }
        }

        public bool SanSang
        {
            get { return _SanSang; }
            set { _SanSang = value; }
        }

        public CaroChess()
        {
            pen = new Pen(Color.Red);
            sbBG = new SolidBrush(Color.FromArgb(192, 255, 255));
            _BanCo = new BanCo(25, 40);
            _MangOCo = new OCo[_BanCo.SoDong, _BanCo.SoCot];
            stack_CacNuocDaDi = new Stack<OCo>();
            stack_CacNuocUndo = new Stack<OCo>();
            _LuotDi = 1;
        }
        #endregion
        #region Các phương thức
        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }
        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new OCo(i, j, new Point(j*OCo._ChieuRong, i*OCo._ChieuCao), 0);
                }
            }    
        }
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % OCo._ChieuRong == 0 || MouseY % OCo._ChieuCao == 0)
                return false;    
            int Cot = MouseX / OCo._ChieuRong;
            int Dong = MouseY / OCo._ChieuCao;

            if (_MangOCo[Dong, Cot].SoHuu != 0)
                return false;

            switch (_LuotDi)
            {
                case 1:
                    _MangOCo[Dong, Cot].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, _LuotDi);
                    _LuotDi = 2;
                    break;
                case 2:
                    _MangOCo[Dong, Cot].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, _LuotDi);
                    _LuotDi = 1;
                    break;   
                default:
                    MessageBox.Show("Có lỗi");
                    break;
            }
            stack_CacNuocUndo = new Stack<OCo>();
            OCo oco = new OCo(_MangOCo[Dong, Cot].Dong, _MangOCo[Dong, Cot].Cot, _MangOCo[Dong, Cot].ViTri, _MangOCo[Dong, Cot].SoHuu);
            stack_CacNuocDaDi.Push(oco);
            return true;
        }
        public void VeLaiQuanCo(Graphics g)
        {
            foreach(OCo oCo in stack_CacNuocDaDi)
            {
                if (oCo.SoHuu == 1)
                    _BanCo.VeQuanCo(g, oCo.ViTri, oCo.SoHuu);
                else if (oCo.SoHuu == 2)
                    _BanCo.VeQuanCo(g, oCo.ViTri, oCo.SoHuu);
            }
        }
        public void StartPlayerVsPlayer(Graphics g)
        {
            _LuotDi = 1;
            _SanSang = true;
            _CheDoChoi = 1;
            stack_CacNuocDaDi = new Stack<OCo>();
            stack_CacNuocUndo = new Stack<OCo>();
            KhoiTaoMangOCo();
            VeBanCo(g);
        }

        public void StartPlayerVsCom(Graphics g)
        {
            _LuotDi = 1;
            _SanSang = true;
            _CheDoChoi = 2;
            stack_CacNuocDaDi = new Stack<OCo>();
            stack_CacNuocUndo = new Stack<OCo>();
            KhoiTaoMangOCo();
            VeBanCo(g);
            KhoiDongComputer(g);
        }
        

        #region Undo - Redo
        public void Undo(Graphics g)
        {
            if (stack_CacNuocDaDi.Count != 0)
            {
                if (CheDoChoi == 1)
                {
                    OCo oco = stack_CacNuocDaDi.Pop();
                    stack_CacNuocUndo.Push(new OCo(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                    //_LuotDi = oco.SoHuu;
                    _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                    _BanCo.XoaQuanCo(g, oco.ViTri, sbBG);
                    if (_LuotDi == 1)
                        _LuotDi = 2;
                    else
                        _LuotDi = 1;
                }
                else
                {
                    if (stack_CacNuocDaDi.Count > 1)
                    {
                        OCo oco = stack_CacNuocDaDi.Pop();
                        OCo oco1 = stack_CacNuocDaDi.Pop();
                        stack_CacNuocUndo.Push(new OCo(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                        stack_CacNuocUndo.Push(new OCo(oco1.Dong, oco1.Cot, oco1.ViTri, oco1.SoHuu));
                        //_LuotDi = oco.SoHuu;
                        _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                        _BanCo.XoaQuanCo(g, oco.ViTri, sbBG);
                        _MangOCo[oco1.Dong, oco1.Cot].SoHuu = 0;
                        _BanCo.XoaQuanCo(g, oco1.ViTri, sbBG);
                    }
                    else
                        return;
                    
                }
            } 
            //VeBanCo(g);
            //VeLaiQuanCo(g);
        }
        public void Redo(Graphics g)
        {
            if (stack_CacNuocUndo.Count != 0)
            {
                OCo oco = stack_CacNuocUndo.Pop();
                stack_CacNuocDaDi.Push(new OCo(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                //_LuotDi = oco.SoHuu == 1 ? 2 : 1;
                _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                _BanCo.VeQuanCo(g, oco.ViTri, _LuotDi);
                if (_LuotDi == 1)
                    _LuotDi = 2;
                else
                    _LuotDi = 1;
            }
            //VeBanCo(g);
            //VeLaiQuanCo(g);
        }
        #endregion

        #region Duyệt chiến thắng
        public void KetThucTroChoi()
        {
            switch (_KetThuc)
            {
                case KETTHUC.HoaCo:
                    MessageBox.Show("Hòa Cờ!", "Trận đấu kết thúc");
                    break;
                case KETTHUC.Player:
                    MessageBox.Show("Bạn thắng!", "Trận đấu kết thúc");
                    break;
                case KETTHUC.Player1:
                    MessageBox.Show("Người chơi 1 thắng!", "Trận đấu kết thúc");
                    break;
                case KETTHUC.Player2:
                    MessageBox.Show("Người chơi 2 thắng!", "Trận đấu kết thúc");
                    break;
                case KETTHUC.Com:
                    MessageBox.Show("Computer thắng!", "Trận đấu kết thúc");
                    break;
                default:
                    break;
            }
            _SanSang = false;
        }
        public bool KiemTraChienThang()
        {
            if (stack_CacNuocDaDi.Count == _BanCo.SoCot * _BanCo.SoDong)
            {
                _KetThuc = KETTHUC.HoaCo;
                return true;
            }
            foreach(OCo oco in stack_CacNuocDaDi)
            {
                if (DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    if (oco.SoHuu == 1)
                        if (_CheDoChoi == 1)
                        {
                            _KetThuc = KETTHUC.Player1;
                        }   
                        else
                        {
                            _KetThuc = KETTHUC.Com;
                        }      
                    else
                        if (_CheDoChoi == 1)
                        {
                            _KetThuc = KETTHUC.Player2;
                        }   
                        else
                        {
                            _KetThuc = KETTHUC.Player;
                        }   
                    return true;
                }
                    
            }
            return false;
        }
        private bool DuyetDoc(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong + Dem == _BanCo.SoDong)
                return true;
            if (_MangOCo[currDong - 1, currCot].SoHuu == 0 || _MangOCo[currDong + Dem, currCot].SoHuu == 0) // Kiem Tra chan 2 dau
                return true;
            return false;
        }
        private bool DuyetNgang(int currDong, int currCot, int currSoHuu)
        {
            if (currCot > _BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currCot == 0 || currCot + Dem == _BanCo.SoCot)
                return true;
            if (_MangOCo[currDong, currCot - 1].SoHuu == 0 || _MangOCo[currDong, currCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetCheoXuoi(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _BanCo.SoDong - 5 || currCot > _BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong + Dem == _BanCo.SoDong || currCot == 0 || currCot + Dem == _BanCo.SoCot)
                return true;
            if (_MangOCo[currDong - 1, currCot - 1].SoHuu == 0 || _MangOCo[currDong + Dem, currCot + Dem].SoHuu == 0) // Kiem Tra chan 2 dau
                return true;
            return false;
        }
        private bool DuyetCheoNguoc(int currDong, int currCot, int currSoHuu)
        {
            if (currDong < 4 || currCot > _BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 4 || currDong == _BanCo.SoDong - 1 || currCot == 0 || currCot + Dem == _BanCo.SoCot) // Kiem tra bien
                return true;
            if (_MangOCo[currDong + 1, currCot - 1].SoHuu == 0 || _MangOCo[currDong - Dem, currCot + Dem].SoHuu == 0) // Kiem Tra chan 2 dau
                return true;
            return false;
        }
        #endregion
        #region AI
        private long[] MangDiemTanCong = new long[7] {0, 3, 24, 192, 1536, 12288, 98304};
        private long[] MangDiemPhongNgu = new long[7] {0, 1, 9, 81, 729, 6561, 59049};
        public void KhoiDongComputer(Graphics g)
        {
            if (stack_CacNuocDaDi.Count == 0)
            {
                DanhCo(_BanCo.SoCot / 2 * OCo._ChieuRong - 1, _BanCo.SoDong / 2 * OCo._ChieuCao - 1, g);
            }
            else
            {
                OCo oco = TimKiemNuocDi();
                DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g);
            }
        }
        private OCo TimKiemNuocDi()
        {
            OCo oCoResult = new OCo();
            long DiemMax = 0;
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    if (_MangOCo[i, j].SoHuu == 0)
                    {
                        long DiemTanCong = DiemTanCong_DuyetDoc(i, j) + DiemTanCong_DuyetNgang(i, j) + DiemTanCong_DuyetCheoNguoc(i, j) + DiemTanCong_DuyetCheoXuoi(i, j);
                        long DiemPhongNgu = DiemPhongNgu_DuyetDoc(i, j) + DiemPhongNgu_DuyetNgang(i, j) + DiemPhongNgu_DuyetCheoNguoc(i, j) + DiemPhongNgu_DuyetCheoXuoi(i, j);
                        long DiemTam = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if (DiemMax < DiemTam)
                        {
                            DiemMax = DiemTam;
                            oCoResult = new OCo(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].ViTri, _MangOCo[i, j].SoHuu);

                        }
                    }
                }
            }

            return oCoResult;
        }
        #region Tấn công
        private long DiemTanCong_DuyetDoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currDong + Dem < _BanCo.SoDong; Dem++) // Duyệt từ trên xuống, currDong + Dem < _BanCo.SoDong để tránh tràn
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu == 1) 
                    SoQuanTa++;
                else if (_MangOCo[currDong + Dem, currCot].SoHuu == 2) 
                {
                    SoQuanDich++;
                    break;
                } else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currDong - Dem >= 0; Dem++) //Duyệt từ dưới lên, currDong - Dem >= 0 để tránh tràn
            {
                if (_MangOCo[currDong - Dem, currCot].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1] * 2;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTong += DiemTC;
            return DiemTong;
        }
        private long DiemTanCong_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _BanCo.SoCot; Dem++) //Duyệt từ trái sang phải
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0; Dem++) // Duyệt từ phải sang trái
            {
                if (_MangOCo[currDong, currCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1] * 2;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTong += DiemTC;
            return DiemTong;
        }
        private long DiemTanCong_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong - Dem >= 0; Dem++) // Duyệt trái dưới lên phải trên
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong + Dem < _BanCo.SoDong; Dem++) // Duyệt phải trên xuống trái dưới
            {
                if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1] * 2;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTong += DiemTC;
            return DiemTong;
        }
        private long DiemTanCong_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong + Dem < _BanCo.SoDong; Dem++) // Duyệt trái trên xuống phải dưới
            {
                if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong - Dem >= 0; Dem++) // Duyệt phải dưới lên trái trên
            {
                if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1] * 2;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTong += DiemTC;
            return DiemTong;
        }
        #endregion

        #region Phòng ngự
        private long DiemPhongNgu_DuyetDoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemPN = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                    
                else if (_MangOCo[currDong - Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemPN += MangDiemPhongNgu[SoQuanDich];
            DiemTong += DiemPN;
            return DiemTong;
        }
        private long DiemPhongNgu_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemPN = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _BanCo.SoCot; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            DiemTong += DiemPN;
            return DiemTong;
        }
        private long DiemPhongNgu_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemPN = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanTa];
            DiemTong += DiemPN;
            return DiemTong;
        }
        private long DiemPhongNgu_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            long DiemPN = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _BanCo.SoCot && currDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            if (SoQuanTa== 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanTa];
            DiemTong += DiemPN;
            return DiemTong;
        }
        #endregion

        #endregion
        #endregion

    }
}
