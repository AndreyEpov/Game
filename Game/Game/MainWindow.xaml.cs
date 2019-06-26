﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        Gaming gema = new Gaming();

        System.Windows.Threading.DispatcherTimer Timer;
        System.Windows.Threading.DispatcherTimer JumpTimer;
        System.Windows.Threading.DispatcherTimer FallTimer;
        System.Windows.Threading.DispatcherTimer MoveTimer;
        System.Windows.Threading.DispatcherTimer ConfirmTimer;
        System.Windows.Threading.DispatcherTimer FightTimer;

        bool tavern = true;
        bool start = false;
        bool forest = false;
        bool tourn = false;

        Rectangle myRect = new Rectangle();
        Rectangle HP = new Rectangle();
        Rectangle FRAME = new Rectangle();
        Rectangle enemy = new Rectangle();
        Rectangle HPENEMY = new Rectangle();
        Rectangle FRAMEENEMY = new Rectangle();
        Rectangle HPENEMY1 = new Rectangle();
        Rectangle FRAMEENEMY1 = new Rectangle();
        Rectangle HPENEMY2 = new Rectangle();
        Rectangle FRAMEENEMY2 = new Rectangle();

        Point f0t1 = new Point(792, 312);
        Point f1t0 = new Point(0, 312);
        Point f1t3 = new Point(264, 312);
        Point f1t4 = new Point(528, 312);
        Point f2t1 = new Point(0, 312);
        Point f2t5 = new Point(600, 312);
        Point f3t1 = new Point(0, 312);
        Point f3t5 = new Point(696, 312);
        Point f4t1 = new Point(696, 312);
        Point f4t5 = new Point(400, 312);
        Point f5t2 = new Point(0, 312);
        Point f5t3 = new Point(150, 312);
        Point f5t4 = new Point(300, 312);
        Point f5t67 = new Point(650, 312);
        Point f5t9 = new Point(792, 312);
        Point f6t8 = new Point(0, 312);
        Point f6t5 = new Point(696, 312);
        Point f8t6 = new Point(792, 312);
        Point f7t5 = new Point(792, 312);
        Point f9t11 = new Point(696, 312);
        Point f11t12 = new Point(396, 312);
        Point f12t14 = new Point(600, 312);
        Point f14t15 = new Point(400, 312);
        Point f1t2 = new Point(750, 312);
        Point tostore = new Point(475, 312);        

        int x = 0, y = 312, pic = 0;
        int up = 0;
        bool canjump = true;
        int enemyshp = 120;
        int enemyshp1 = 120;
        int zombhp = 100;
        int wizardshp = 300;
        int planthp = 120;
        public int usedheal = 0;
        public int gold = 0;
        int cost;
        int count = 0, victory = 0;
        int slime1hp = 175, slime2hp = 140, slime3hp = 140;
        int en1hp = 200, en2hp = 200;
        int knighthp = 150, pirate = 150;
        int bard = 0, xb = 650, by = 312;
        bool right = false;

        int hph = 16, hpw = 96;

        int currentFrame = 1, currentRow = 0, cr = 8;
        int frameW = 96, frameH = 96;
        bool boolat = false;

        Rectangle enemy1 = new Rectangle();
        Rectangle enemy2 = new Rectangle();
        Rectangle enemy3 = new Rectangle();

        ImageBrush background = new ImageBrush();

        store store = new store();

        public MainWindow()
        {
            InitializeComponent();

            screen.KeyDown += Window_KeyDown;

            FRAME.Height = 16;
            FRAME.Width = 96;
            FRAME.Stroke = Brushes.Black;
            FRAME.HorizontalAlignment = HorizontalAlignment.Left;
            FRAME.VerticalAlignment = VerticalAlignment.Center;
            FRAME.Margin = new Thickness(696, 0, 0, 0);
            screen.Children.Add(FRAME);

            HP.Height = hph;
            HP.Width = hpw;
            HP.Stroke = Brushes.Black;
            HP.Fill = Brushes.Green;
            HP.HorizontalAlignment = HorizontalAlignment.Left;
            HP.VerticalAlignment = VerticalAlignment.Center;
            HP.Margin = new Thickness(696, 0, 0, 0);
            screen.Children.Add(HP);

            myRect.Height = 96;
            myRect.Width = 96;
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            //ib.AlignmentY = AlignmentY.Top;
            ib.Stretch = Stretch.None;
            ib.Viewbox = new Rect(0, 0, 96, 96);
            ib.ViewboxUnits = BrushMappingMode.Absolute;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/gg.gif", UriKind.Absolute));
            myRect.Fill = ib;
            myRect.Margin = new Thickness(0, 0, 0, 0);
            screen.Children.Add(myRect);

            background.AlignmentX = AlignmentX.Left;
            background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/внутри дома.bmp", UriKind.Absolute));
            screen.Background = background;

            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 125);

            JumpTimer = new System.Windows.Threading.DispatcherTimer();
            JumpTimer.Tick += new EventHandler(JumpTimer_Tick);
            JumpTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);

            FallTimer = new System.Windows.Threading.DispatcherTimer();
            FallTimer.Tick += new EventHandler(FallTimer_Tick);
            FallTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            FallTimer.Start();

            MoveTimer = new System.Windows.Threading.DispatcherTimer();
            MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
            MoveTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            MoveTimer.Start();

            ConfirmTimer = new System.Windows.Threading.DispatcherTimer();
            ConfirmTimer.Tick += new EventHandler(ConfirmTimer_Tick);
            ConfirmTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            ConfirmTimer.Start();

            FightTimer = new System.Windows.Threading.DispatcherTimer();
            FightTimer.Tick += new EventHandler(FightTimer_Tick);
            FightTimer.Interval = new TimeSpan(0, 0, 0, 0, 400);
        }

        private void JumpTimer_Tick(object sender, EventArgs e)
        {
            canjump = false;
            y -= 8;
            up += 1;
            if (up == 10)
            {
                JumpTimer.Stop();
                up = 0;
                FallTimer.Start();

            }
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            myRect.RenderTransform = new TranslateTransform(x, y);
            you.Content = " Золото: " + gold + "  \n Защита: " + gema.armor + "  \n Оружие: " + gema.weapon + "  \n [h]Хилка: " + gema.heal + " ";
            if (bard == 1)
            {
                if (right==false)
                {
                    xb -= 8;
                    if (xb < 10)
                        right = true;
                }
                else
                {
                    xb += 8;
                    if (xb > 680)
                        right = false;
                }
                enemy1.RenderTransform = new TranslateTransform(xb, by);
                screen.UpdateLayout();
            }
        }

        private void ConfirmTimer_Tick(object sender, EventArgs e)
        {
            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            if (pic == 0) // из дома в деревню
            {
                if (rect.Contains(f0t1) == true && tavern == true && start == false)
                    confirm.Content = "[t]Начать экшон";
                else confirm.Content = "";
                if (rect.Contains(f0t1) == true && start == true)
                    confirm.Content = "[e]Выйти в деревню";
            }

            if (pic == 1) // из деревни
            {
                if (rect.Contains(f1t0) == true && tavern == false)
                    confirm.Content = "[e]Войти в дом";
                if (rect.Contains(f1t0) == true && tavern == true && forest == true)
                    confirm.Content = "[t]Войти в таверну";
                if (rect.Contains(f1t2) == true && tavern == false)
                    confirm.Content = "[e]На поляну";
                if (rect.Contains(f1t3) == true)
                    confirm.Content = "[e]В лес";
                if (rect.Contains(f1t4) == true && tavern == false)
                    confirm.Content = "[e]На болото";
                if ((rect.Contains(f1t0) == false) && rect.Contains(f0t1) == false && rect.Contains(f1t3) == false && rect.Contains(f1t4) == false)
                    confirm.Content = "";
            }

            if (pic == 2) // из поляны
            {
                if (rect.Contains(f2t1) == true)
                    confirm.Content = "[e]В деревню";
                if (rect.Contains(f2t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f2t5) == false && rect.Contains(f2t1) == false)
                    confirm.Content = "";
            }

            if (pic == 3) // из леса
            {
                if (rect.Contains(f3t1) == true)
                    confirm.Content = "[e]В деревню";
                if (rect.Contains(f3t5) == true && tavern == false)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f3t1) == false && rect.Contains(f3t5) == false)
                    confirm.Content = "";
            }

            if (pic == 4) // из болота
            {
                if (rect.Contains(f4t1) == true)
                    confirm.Content = "[e]В деревню";
                if (rect.Contains(f4t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f4t1) == false && rect.Contains(f4t5) == false)
                    confirm.Content = "";
            }

            if (pic == 5) // из замка
            {
                if (rect.Contains(tostore))
                    confirm.Content = "[b]В магазин\n[e]К барду";
                if (rect.Contains(f5t2) == true)
                    confirm.Content = "[e]На поляну";
                if (rect.Contains(f5t3) == true)
                    confirm.Content = "[e]В лес";
                if (rect.Contains(f5t4) == true)
                    confirm.Content = "[e]На болото";
                if (rect.Contains(f5t67) == true)
                    confirm.Content = "[e]В пещеру\n[t]К руинам";
                if (rect.Contains(f5t9) == true)
                    confirm.Content = "[e]На рыцарский турнир";
                if (rect.Contains(f5t2) == false && rect.Contains(f5t3) == false && rect.Contains(f5t4) == false && rect.Contains(f5t67) == false && rect.Contains(f5t9) == false && rect.Contains(tostore) == false)
                    confirm.Content = "";
            }

            if (pic == 6) // из пещеры
            {
                if (rect.Contains(f6t5) == true)
                    confirm.Content = "[e]В замок";
                if (rect.Contains(f6t8) == true)
                    confirm.Content = "[e]В сердце пещеры";
                if (rect.Contains(f6t8) == false && rect.Contains(f6t5) == false)
                    confirm.Content = "";
            }

            if (pic == 7) // из руин
            {
                if (rect.Contains(f7t5) == true)
                    confirm.Content = "[e]В замок";
                else confirm.Content = "";
            }

            if (pic == 8) // из сердца пещеры
            {
                if (rect.Contains(f8t6) == true)
                    confirm.Content = "[e]В пещеру";
                else confirm.Content = "";

            }

            if (pic == 9) // из рыцарского турнира
            {
                if (rect.Contains(f9t11) == true)
                    confirm.Content = "[e]К маяку";
                else confirm.Content = "";
            }

            if (pic == 11) // от маяка
            {
                if (rect.Contains(f11t12) == true)
                    confirm.Content = "[e]На корабль";
                else confirm.Content = "";
            }

            if (pic == 12) // с корабля
            {
                if (rect.Contains(f12t14) == true)
                    confirm.Content = "[e]К башне";
                else confirm.Content = "";
            }

            if (pic == 14) // от башни
            {
                if (rect.Contains(f14t15) == true)
                    confirm.Content = "[e]Финальный бой";
                else confirm.Content = "";
            }
        }

        private void FallTimer_Tick(object sender, EventArgs e)
        {
            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            //if (rect.IntersectsWith(rect11))
            //{
            //    MessageBox.Show("Da");
            //}

            if (y < 312)
            {
                y += 8;
            }
            else
            {
                canjump = true;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            store.Close();
        }

        private void FightTimer_Tick(object sender, EventArgs e)
        {
            //Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            //Point e1 = new Point(350, 312);
            //Point e2 = new Point(412, 312);
            //Point e3 = new Point(412, 248);
            //Point e4 = new Point(350, 248);

            //if ((rect.Contains(e1) || rect.Contains(e2) || rect.Contains(e3) || rect.Contains(e4)) && pic == 3 && canfight == true)
            //{

            //}
            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
            if (hpw < 96)
                hpw += 2;
            if (hpw >= 0)
                HP.Width = hpw;
            

            Point e1 = new Point(350, 312);
            Point e2 = new Point(412, 312);
            Point e3 = new Point(412, 248);
            Point e4 = new Point(350, 248);// в лесу

            Point p1 = new Point(446, 312);
            Point p2 = new Point(508, 312);
            Point p3 = new Point(508, 248);
            Point p4 = new Point(446, 248);// в лесу

            if ((rect.Contains(p1) || rect.Contains(p2) || rect.Contains(p3) || rect.Contains(p4)) && pic == 3 && screen.Children.Contains(enemy2)) // из первой во вторую
            {
                hpw = hpw - 15 + gema.armor;
            }

            Point e11 = new Point(0, 312);
            Point e22 = new Point(96, 312);
            Point e33 = new Point(0, 248);
            Point e44 = new Point(96, 248);// в сердце пещеры

            if ((rect.Contains(e1) || rect.Contains(e2) || rect.Contains(e3) || rect.Contains(e4)) && pic == 3 && screen.Children.Contains(enemy1)) // из первой во вторую
            {
                hpw = hpw - 15 + gema.armor;
            }       

            if ((rect.Contains(e11) || rect.Contains(e22) || rect.Contains(e33) || rect.Contains(e44)) && (pic == 8 || pic == 7) && screen.Children.Contains(enemy))
            {
                hpw = hpw - 30 + gema.armor;
            }

            Point e111 = new Point(696, 312);
            Point e222 = new Point(792, 312);
            Point e333 = new Point(696, 248);
            Point e444 = new Point(792, 248);

            if ((rect.Contains(e111) || rect.Contains(e222) || rect.Contains(e333) || rect.Contains(e444)) && pic == 15 && screen.Children.Contains(enemy))
            {
                hpw = hpw - 55 + gema.armor;
            }

            Point s1 = new Point(0, 312);
            Point s2 = new Point(64, 312);
            Point s3 = new Point(0, 248);
            Point s4 = new Point(64, 248);

            if ((rect.Contains(s1) || rect.Contains(s2) || rect.Contains(s3) || rect.Contains(s4)) && pic == 4 && screen.Children.Contains(enemy1))
            {
                hpw = hpw - 30 + gema.armor;
            }

            Point s11 = new Point(64, 312);
            Point s22 = new Point(128, 312);
            Point s33 = new Point(128, 248);
            Point s44 = new Point(64, 248);

            if ((rect.Contains(s11) || rect.Contains(s22) || rect.Contains(s33) || rect.Contains(s44)) && pic == 4 && screen.Children.Contains(enemy2))
            {
                hpw = hpw - 30 + gema.armor;
            }

            if ((rect.Contains(e1) || rect.Contains(e2) || rect.Contains(e3) || rect.Contains(e4)) && pic == 2 && screen.Children.Contains(enemy1)) // из первой во вторую
            {
                hpw = hpw - 20 + gema.armor;
            }

            Point s111 = new Point(128, 312);
            Point s222 = new Point(192, 312);
            Point s333 = new Point(128, 248);
            Point s444 = new Point(192, 248);

            if ((rect.Contains(s111) || rect.Contains(s222) || rect.Contains(s333) || rect.Contains(s444)) && pic == 4 && screen.Children.Contains(enemy3))
            {
                hpw = hpw - 70 + gema.armor;
            }

            Point en1 = new Point(200, 312);
            Point en2 = new Point(296, 312);
            Point en3 = new Point(200, 216);
            Point en4 = new Point(296, 216);

            Point en11 = new Point(300, 312);
            Point en22 = new Point(396, 312);
            Point en33 = new Point(300, 216);
            Point en44 = new Point(396, 216);

            if ((rect.Contains(en1) || rect.Contains(en2) || rect.Contains(en3) || rect.Contains(en4)) && pic == 14 && screen.Children.Contains(enemy1))
            {
                hpw = hpw - 55 + gema.armor;
            }

            if ((rect.Contains(en11) || rect.Contains(en22) || rect.Contains(en33) || rect.Contains(en44)) && pic == 14 && screen.Children.Contains(enemy2))
            {
                hpw = hpw - 55 + gema.armor;
            }

            Point t1 = new Point(350, 312);
            Point t2 = new Point(350, 216);
            Point t3 = new Point(446, 312);
            Point t4 = new Point(446, 216);

            Point t11 = new Point(500, 312);
            Point t22 = new Point(596, 216);
            Point t33 = new Point(500, 312);
            Point t44 = new Point(596, 216);

            if ((rect.Contains(t1) || rect.Contains(t2) || rect.Contains(t3) || rect.Contains(t4)) && pic == 9 && screen.Children.Contains(enemy1))
            {
                hpw = hpw - 45 + gema.armor;
            }

            if ((rect.Contains(t11) || rect.Contains(t22) || rect.Contains(t33) || rect.Contains(t44)) && pic == 9 && screen.Children.Contains(enemy2))
            {
                hpw = hpw - 45 + gema.armor;
            }

            if (pirate<=0)
            {
                victory++;
                screen.Children.Remove(enemy1);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                pirate = 150;
            }

            if (planthp<=0)
            {
                screen.Children.Remove(enemy1);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                planthp = 120;
            }

            if (knighthp <= 0)
            {
                victory++;
                screen.Children.Remove(enemy2);
                screen.Children.Remove(HPENEMY1);
                screen.Children.Remove(FRAMEENEMY1);
                knighthp = 150;
            }

            if (victory == 2)
                tourn = true;

            if (hpw <= 0)
            {
                if (MessageBox.Show("LOL You Died :D. Want to continue without money?", "/n", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    x = 0;
                    y = 0;
                    hpw = 96;
                    pic = 0;
                    gold = 0;
                    count = 0;
                    screen.Children.Remove(enemy);
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/внутри дома.bmp", UriKind.Absolute));
                    screen.Background = background;
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY2);
                    screen.Children.Remove(FRAMEENEMY2);
                    screen.Children.Remove(enemy3);
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            if (zombhp <= 0)
            {
                screen.Children.Remove(enemy);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                zombhp = 100;
            }
            if (hpw > 0 && enemyshp > 0 && pic == 8)
            {
                HP.Width = hpw;
                HPENEMY.Width = zombhp;
            }         
            
            if (en1hp <= 0)
            {
                screen.Children.Remove(enemy1);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                en1hp = 200;
            }

            if (en2hp <= 0)
            {
                screen.Children.Remove(enemy2);
                screen.Children.Remove(HPENEMY1);
                screen.Children.Remove(FRAMEENEMY1);
                en2hp = 200;
            }

            if (wizardshp <= 0)
            {
                screen.Children.Remove(enemy);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                if (MessageBox.Show("WINNER WINNER CHICKEN DINNER", "\n", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    Application.Current.Shutdown();
                }

            }
            if (slime1hp <= 0)
            {
                count++;
                screen.Children.Remove(enemy1);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                slime1hp = 170;
            }
            if (slime2hp <= 0)
            {
                count++;
                screen.Children.Remove(enemy2);
                screen.Children.Remove(HPENEMY1);
                screen.Children.Remove(FRAMEENEMY1);
                slime2hp = 140;
            }
            if (slime3hp <= 0)
            {
                count++;
                screen.Children.Remove(enemy3);
                screen.Children.Remove(HPENEMY2);
                screen.Children.Remove(FRAMEENEMY2);
                slime3hp = 140;
            }

            if (enemyshp <= 0)
            {
                count++;
                screen.Children.Remove(enemy1);
                screen.Children.Remove(HPENEMY);
                screen.Children.Remove(FRAMEENEMY);
                enemyshp = 120;
            }
            if (enemyshp1 <= 0)
            {
                count++;
                screen.Children.Remove(enemy2);
                screen.Children.Remove(HPENEMY1);
                screen.Children.Remove(FRAMEENEMY1);
                enemyshp1 = 120;
            }
            if (count==2)
            {
                forest = true;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            var frameLeft = currentFrame * frameW;
            var frameTop = currentRow * frameH;
            (myRect.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);
            if (currentFrame % cr == 0)
            {
                currentRow++;
                currentFrame = 0;
            }
            currentFrame++;

            if (currentFrame == 8)
            {
                currentFrame = 1;
                boolat = false;
            }
            Timer.Stop();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F9)
            {
                hpw += 1000000000;
                HP.Width = hpw;
            }

            if ((e.Key != Key.Right) && (e.Key != Key.Left))
            {
                //Timer.Start();
                //myRect.Height = 96;
                //myRect.Width = 96;
                //ImageBrush ib = new ImageBrush();
                //ib.AlignmentX = AlignmentX.Left;
                //ib.Viewbox = new Rect(0, 0, 96, 96);
                //ib.ViewboxUnits = BrushMappingMode.Absolute;
                //Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                //ib.Stretch = Stretch.None;
                //ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/zomb.gif", UriKind.Absolute));
                //myRect.Fill = ib;
                //myRect.Margin = new Thickness(0, 0, 0, 0);
            }

            if (e.Key == Key.Right)
            {
                Timer.Start();
                if (boolat == false)
                {
                    boolat = true;
                    myRect.Height = 96;
                    myRect.Width = 96;
                    ImageBrush ib = new ImageBrush();
                    ib.AlignmentX = AlignmentX.Left;
                    ib.Viewbox = new Rect(0, 0, 96, 96);
                    ib.ViewboxUnits = BrushMappingMode.Absolute;
                    Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                    ib.Stretch = Stretch.None;
                    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/ggrunforw.gif", UriKind.Absolute));
                    myRect.Fill = ib;
                    myRect.Margin = new Thickness(0, 0, 0, 0);
                }
                if (x < 696)
                    x += 8;
            }

            if (e.Key == Key.Left)
            {
                Timer.Start();
                if (boolat == false)
                {
                    boolat = true;
                    myRect.Height = 96;
                    myRect.Width = 96;
                    ImageBrush ib = new ImageBrush();
                    ib.AlignmentX = AlignmentX.Left;
                    ib.Viewbox = new Rect(0, 0, 96, 96);
                    ib.ViewboxUnits = BrushMappingMode.Absolute;
                    Rect Rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
                    ib.Stretch = Stretch.None;
                    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/ggrunbackwa.gif", UriKind.Absolute));
                    myRect.Fill = ib;
                    myRect.Margin = new Thickness(0, 0, 0, 0);
                }
                if (x > 0)
                    x -= 8;

            }

            if (e.Key == Key.Up)
            {
                if (canjump == true)
                {
                    FallTimer.Stop();
                    JumpTimer.Start();

                }
            }

            if (e.Key == Key.Down)
            {
                //y += 8;
            }

            Rect rect = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);

            if (rect.Contains(tostore) && pic == 5)
            {
                if (e.Key == Key.B)
                {
                    cost = store.gold;

                    store.ShowDialog();

                    gema.armor = store.armor;

                    gema.weapon = store.weapon;

                    gema.heal = store.heal - usedheal;
                    //store.staff
                    gold = gold - store.gold + cost;
                }

                if (e.Key == Key.E)
                {
                    bard = 1;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/bard.png", UriKind.Absolute));
                    screen.Background = background;
                    ImageBrush girl = new ImageBrush();
                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    girl.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    girl.Stretch = Stretch.None;
                    girl.Viewbox = new Rect(0, 0, 96, 96);
                    girl.ViewboxUnits = BrushMappingMode.Absolute;
                    girl.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/princess.gif", UriKind.Absolute));
                    enemy1.Fill = girl;
                    enemy1.Margin = new Thickness(650, 312, 0, 0);
                    screen.Children.Add(enemy1);
                }
            }

            if (gema.heal > 0)
            {
                if (e.Key == Key.H)
                {
                    gema.heal = gema.heal - 1;
                    hpw = hpw + 30;
                }
            }

            Point e1 = new Point(350, 312);
            Point e2 = new Point(412, 312);
            Point e3 = new Point(412, 248);
            Point e4 = new Point(350, 248);

            if ((rect.Contains(e1) || rect.Contains(e2) || rect.Contains(e3) || rect.Contains(e4)) && pic == 3 && screen.Children.Contains(enemy1)) // из первой во вторую
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy1))
                {
                    enemyshp = enemyshp - (6 * gema.weapon);
                    if (enemyshp > 0 && pic == 3)
                        HPENEMY.Width = enemyshp;
                }
            }

            if ((rect.Contains(e1) || rect.Contains(e2) || rect.Contains(e3) || rect.Contains(e4)) && pic == 2 && screen.Children.Contains(enemy1)) // из первой во вторую
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy1))
                {
                    planthp = planthp - (6 * gema.weapon);
                    if (planthp > 0 && pic == 2)
                        HPENEMY.Width = planthp;
                }
            }

            Point p1 = new Point(446, 312);
            Point p2 = new Point(508, 312);
            Point p3 = new Point(508, 248);
            Point p4 = new Point(446, 248);// в лесу

            if ((rect.Contains(p1) || rect.Contains(p2) || rect.Contains(p3) || rect.Contains(p4)) && pic == 3 && screen.Children.Contains(enemy2)) // из первой во вторую
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy2))
                {
                    enemyshp1 = enemyshp1 - (6 * gema.weapon);
                    if (enemyshp1 > 0 && pic == 3)
                        HPENEMY1.Width = enemyshp1;
                }
            }

            Point e11 = new Point(0, 312);
            Point e22 = new Point(96, 312);
            Point e33 = new Point(0, 248);
            Point e44 = new Point(96, 248);

            if ((rect.Contains(e11) || rect.Contains(e22) || rect.Contains(e33) || rect.Contains(e44)) && pic == 8 && screen.Children.Contains(enemy))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy))
                {
                    zombhp = zombhp - (6 * gema.weapon);
                    if (zombhp>0)
                        HPENEMY.Width = zombhp;
                }

            }

            if ((rect.Contains(e11) || rect.Contains(e22) || rect.Contains(e33) || rect.Contains(e44)) && pic == 7 && screen.Children.Contains(enemy))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy))
                {
                    zombhp = zombhp - (6 * gema.weapon);
                    if (zombhp > 0)
                        HPENEMY.Width = zombhp;
                }

            }

            Point s1 = new Point(0, 312);
            Point s2 = new Point(64, 312);
            Point s3 = new Point(0, 248);
            Point s4 = new Point(64, 248);

            if ((rect.Contains(s1) || rect.Contains(s2) || rect.Contains(s3) || rect.Contains(s4)) && pic == 4 && screen.Children.Contains(enemy1))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy1))
                {
                    slime1hp = slime1hp - (6 * gema.weapon);
                    if (slime1hp>0)
                        HPENEMY.Width = slime1hp;
                }
            }

            Point s11 = new Point(64, 312);
            Point s22 = new Point(128, 312);
            Point s33 = new Point(128, 248);
            Point s44= new Point(64, 248);

            if ((rect.Contains(s11) || rect.Contains(s22) || rect.Contains(s33) || rect.Contains(s44)) && pic == 4 && screen.Children.Contains(enemy2))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy2))
                {
                    slime2hp = slime2hp - (6 * gema.weapon);
                    if (slime2hp > 0)
                        HPENEMY1.Width = slime2hp;
                }
            }

            Point s111 = new Point(128, 312);
            Point s222 = new Point(192, 312);
            Point s333 = new Point(128, 248);
            Point s444 = new Point(192, 248);

            if ((rect.Contains(s111) || rect.Contains(s222) || rect.Contains(s333) || rect.Contains(s444)) && pic == 4 && screen.Children.Contains(enemy3))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy3))
                {
                    slime3hp = slime3hp - (6 * gema.weapon);
                    if (slime3hp > 0)
                        HPENEMY2.Width = slime3hp;
                }
            }

            Point t1 = new Point(350, 312);
            Point t2 = new Point(350, 216);
            Point t3 = new Point(446, 312);
            Point t4 = new Point(446, 216);

            Point t11 = new Point(500, 312);
            Point t22 = new Point(596, 216);
            Point t33 = new Point(500, 312);
            Point t44 = new Point(596, 216);

            if ((rect.Contains(t1) || rect.Contains(t2) || rect.Contains(t3) || rect.Contains(t4)) && pic == 9 && screen.Children.Contains(enemy1))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy1))
                {
                    pirate = pirate - (6 * gema.weapon);
                    if (pirate > 0)
                        HPENEMY.Width = pirate;
                }
            }

            if ((rect.Contains(t11) || rect.Contains(t22) || rect.Contains(t33) || rect.Contains(t44)) && pic == 9 && screen.Children.Contains(enemy2))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy2))
                {
                    knighthp = knighthp- (6 * gema.weapon);
                    if (knighthp > 0)
                        HPENEMY1.Width = knighthp;
                }
            }

            if (rect.Contains(f5t9) == true && pic == 5) // из замка на рыцарский турнир
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/арена2.png.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 9;
                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/PIRATE.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);

                    enemy2.Height = 96;
                    enemy2.Width = 96;
                    ImageBrush rival1 = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival1.Stretch = Stretch.None;
                    rival1.Viewbox = new Rect(0, 0, 96, 96);
                    rival1.ViewboxUnits = BrushMappingMode.Absolute;
                    rival1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/na_areny.gif", UriKind.Absolute));
                    enemy2.Fill = rival1;
                    enemy2.Margin = new Thickness(500, 312, 0, 0);
                    screen.Children.Add(enemy2);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 120;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = enemyshp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(HPENEMY);

                    FRAMEENEMY1.Height = 16;
                    FRAMEENEMY1.Width = 120;
                    FRAMEENEMY1.Stroke = Brushes.Black;
                    FRAMEENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY1.Margin = new Thickness(500, 278, 0, 0);
                    screen.Children.Add(FRAMEENEMY1);

                    HPENEMY1.Height = hph;
                    HPENEMY1.Width = enemyshp;
                    HPENEMY1.Stroke = Brushes.Black;
                    HPENEMY1.Fill = Brushes.Red;
                    HPENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY1.Margin = new Thickness(500, 278, 0, 0);
                    screen.Children.Add(HPENEMY1);
                }
            }

            if (rect.Contains(f6t5) == true && pic == 6) // из пещеры в замок
            {
                if (e.Key == Key.E)
                {
                    x = 650;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                }
            }

            if (rect.Contains(f5t67) == true && pic == 5) // из замка в пещеру/руины
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/подземелье.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 6;
                }
                if (e.Key == Key.T)
                {
                    x = 696;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/руины.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 7;
                    enemy.Height = 128;
                    enemy.Width = 128;
                    ImageBrush ib = new ImageBrush();
                    ib.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    ib.Stretch = Stretch.None;
                    ib.Viewbox = new Rect(0, 0, 128, 128);
                    ib.ViewboxUnits = BrushMappingMode.Absolute;
                    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/orc3.gif", UriKind.Absolute));
                    enemy.Fill = ib;
                    enemy.Margin = new Thickness(0, 280, 0, 0);
                    screen.Children.Add(enemy);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 100;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(0, 262, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = zombhp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(0, 262, 0, 0);
                    screen.Children.Add(HPENEMY);
                }
            }

            if ((rect.Contains(f2t5) == true) && (pic == 2) && tavern == false) // из поляны в замок
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                }
            }

            if ((rect.Contains(f1t2) == true) && (pic == 1)) // из деревни на поляну
            {
                if (e.Key == Key.E && tavern == false)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/поляна.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 2;

                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/BLYANT.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 120;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = enemyshp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(HPENEMY);
                }
            }

            if (rect.Contains(f9t11) == true && pic == 9 && tourn == true) // к маяку
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/маяк.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 11;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/PIRATE.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);
                }
            }

            if ((rect.Contains(f0t1) == true) && (pic == 0)) // из дома в деревню
            {
                if (start == false)
                {
                    if (e.Key == Key.T)
                    {
                        x = 0;
                        y = 216;
                        background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/таверна.png", UriKind.Absolute));
                        screen.Background = background;
                        start = true;
                        ImageBrush girl = new ImageBrush();
                        enemy1.Height = 96;
                        enemy1.Width = 96;
                        girl.AlignmentX = AlignmentX.Left;
                        //ib.AlignmentY = AlignmentY.Top;
                        girl.Stretch = Stretch.None;
                        girl.Viewbox = new Rect(0, 0, 96, 96);
                        girl.ViewboxUnits = BrushMappingMode.Absolute;
                        girl.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/tavernwoman.gif", UriKind.Absolute));
                        enemy1.Fill = girl;
                        enemy1.Margin = new Thickness(300, 312, 0, 0);
                        screen.Children.Add(enemy1);
                    }
                }
                else
                {
                    if (e.Key == Key.E)
                    {
                        x = 0;
                        y = 216;
                        background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                        screen.Background = background;
                        pic = 1;
                        screen.Children.Remove(enemy1);
                    }
                }
            }

            Point tav = new Point(348, 312);

            if ((rect.Contains(f1t0) == true) && (pic == 1)) // из деревни в дом
            {
                if (forest == true)
                {
                    if (tavern == false)
                    {
                        if (e.Key == Key.E)
                        {
                            x = 696;
                            y = 216;
                            background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/внутри дома.bmp", UriKind.Absolute));
                            screen.Background = background;
                            pic = 0;
                        }
                    }
                    else
                    {
                        if (e.Key == Key.T)
                        {
                            x = 696;
                            y = 216;
                            background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/таверна.png", UriKind.Absolute));
                            screen.Background = background;
                            pic = 0;
                            ImageBrush girl = new ImageBrush();
                            enemy1.Height = 96;
                            enemy1.Width = 96;
                            girl.AlignmentX = AlignmentX.Left;
                            //ib.AlignmentY = AlignmentY.Top;
                            girl.Stretch = Stretch.None;
                            girl.Viewbox = new Rect(0, 0, 96, 96);
                            girl.ViewboxUnits = BrushMappingMode.Absolute;
                            girl.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/tavernwomanreverse.gif", UriKind.Absolute));
                            enemy1.Fill = girl;
                            enemy1.Margin = new Thickness(300, 312, 0, 0);
                            screen.Children.Add(enemy1);
                        }
                    }
                }
            }

            if (rect.Contains(tav) == true && pic == 0 && tavern == true && forest == true)
            {
                tavern = false;
                gold = gold + 300;
            }

            if ((rect.Contains(f1t3) == true) && (pic == 1)) // из деревни в лес
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/лес.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 3;
                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/loh1reverse.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);

                    enemy2.Height = 96;
                    enemy2.Width = 96;
                    ImageBrush rival1 = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival1.Stretch = Stretch.None;
                    rival1.Viewbox = new Rect(0, 0, 96, 96);
                    rival1.ViewboxUnits = BrushMappingMode.Absolute;
                    rival1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/loh2reverse.gif", UriKind.Absolute));
                    enemy2.Fill = rival1;
                    enemy2.Margin = new Thickness(446, 312, 0, 0);
                    screen.Children.Add(enemy2);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 120;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = enemyshp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(HPENEMY);

                    FRAMEENEMY1.Height = 16;
                    FRAMEENEMY1.Width = 120;
                    FRAMEENEMY1.Stroke = Brushes.Black;
                    FRAMEENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY1.Margin = new Thickness(446, 278, 0, 0);
                    screen.Children.Add(FRAMEENEMY1);

                    HPENEMY1.Height = hph;
                    HPENEMY1.Width = enemyshp;
                    HPENEMY1.Stroke = Brushes.Black;
                    HPENEMY1.Fill = Brushes.Red;
                    HPENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY1.Margin = new Thickness(446, 278, 0, 0);
                    screen.Children.Add(HPENEMY1);
                }
            }

            if ((rect.Contains(f1t4) == true) && (pic == 1) && tavern == false) // из деревни на болото
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/болото.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 4;

                    enemy1.Height = 64;
                    enemy1.Width = 64;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime2.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(0, 344, 0, 0);
                    screen.Children.Add(enemy1);

                    enemy2.Height = 64;
                    enemy2.Width = 64;
                    ImageBrush rival1 = new ImageBrush();
                    rival1.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival1.Stretch = Stretch.None;
                    rival1.Viewbox = new Rect(0, 0, 96, 96);
                    rival1.ViewboxUnits = BrushMappingMode.Absolute;
                    rival1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime1.gif", UriKind.Absolute));
                    enemy2.Fill = rival1;
                    enemy2.Margin = new Thickness(64, 344, 0, 0);
                    screen.Children.Add(enemy2);

                    enemy3.Height = 64;
                    enemy3.Width = 64;
                    ImageBrush rival2 = new ImageBrush();
                    rival2.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival2.Stretch = Stretch.None;
                    rival2.Viewbox = new Rect(0, 0, 96, 96);
                    rival2.ViewboxUnits = BrushMappingMode.Absolute;
                    rival2.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime1.gif", UriKind.Absolute));
                    enemy3.Fill = rival2;
                    enemy3.Margin = new Thickness(128, 344, 0, 0);
                    screen.Children.Add(enemy3);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 175;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(0, 290, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = slime1hp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(0, 290, 0, 0);
                    screen.Children.Add(HPENEMY);

                    FRAMEENEMY1.Height = 16;
                    FRAMEENEMY1.Width = 140;
                    FRAMEENEMY1.Stroke = Brushes.Black;
                    FRAMEENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY1.Margin = new Thickness(40, 308, 0, 0);
                    screen.Children.Add(FRAMEENEMY1);

                    HPENEMY1.Height = hph;
                    HPENEMY1.Width = slime2hp;
                    HPENEMY1.Stroke = Brushes.Black;
                    HPENEMY1.Fill = Brushes.Red;
                    HPENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY1.Margin = new Thickness(40, 308, 0, 0);
                    screen.Children.Add(HPENEMY1);

                    FRAMEENEMY2.Height = 16;
                    FRAMEENEMY2.Width = 140;
                    FRAMEENEMY2.Stroke = Brushes.Black;
                    FRAMEENEMY2.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY2.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY2.Margin = new Thickness(114, 326, 0, 0);
                    screen.Children.Add(FRAMEENEMY2);

                    HPENEMY2.Height = hph;
                    HPENEMY2.Width = slime3hp;
                    HPENEMY2.Stroke = Brushes.Black;
                    HPENEMY2.Fill = Brushes.Red;
                    HPENEMY2.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY2.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY2.Margin = new Thickness(114, 326, 0, 0);
                    screen.Children.Add(HPENEMY2);

                }
            }

            if ((rect.Contains(f2t1) == true) && (pic == 2)) // из поляны в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                }
            }

            if (rect.Contains(f3t1) == true && pic == 3) // из леса в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 264;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                }
            }

            if (rect.Contains(f3t5) == true && pic == 3) // из леса в замок
            {
                if (e.Key == Key.E && tavern == false)
                {
                    x = 150;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                    screen.Children.Remove(enemy);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                }
            }

            if (rect.Contains(f4t1) == true && pic == 4) // из болота в деревню
            {
                if (e.Key == Key.E)
                {
                    x = 528;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/деревня.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 1;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                    screen.Children.Remove(enemy3);
                    screen.Children.Remove(HPENEMY2);
                    screen.Children.Remove(FRAMEENEMY2);
                }
            }

            if (rect.Contains(f5t4) == true && pic == 5) // из замка на болото
            {
                if (e.Key == Key.E)
                {
                    x = 400;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/болото.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 4;
                    enemy1.Height = 64;
                    enemy1.Width = 64;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime2.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(0, 344, 0, 0);
                    screen.Children.Add(enemy1);

                    enemy2.Height = 64;
                    enemy2.Width = 64;
                    ImageBrush rival1 = new ImageBrush();
                    rival1.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival1.Stretch = Stretch.None;
                    rival1.Viewbox = new Rect(0, 0, 96, 96);
                    rival1.ViewboxUnits = BrushMappingMode.Absolute;
                    rival1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime1.gif", UriKind.Absolute));
                    enemy2.Fill = rival1;
                    enemy2.Margin = new Thickness(64, 344, 0, 0);
                    screen.Children.Add(enemy2);

                    enemy3.Height = 64;
                    enemy3.Width = 64;
                    ImageBrush rival2 = new ImageBrush();
                    rival2.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival2.Stretch = Stretch.None;
                    rival2.Viewbox = new Rect(0, 0, 96, 96);
                    rival2.ViewboxUnits = BrushMappingMode.Absolute;
                    rival2.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/slime1.gif", UriKind.Absolute));
                    enemy3.Fill = rival2;
                    enemy3.Margin = new Thickness(128, 344, 0, 0);
                    screen.Children.Add(enemy3);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 175;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(0, 290, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = slime1hp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(0, 290, 0, 0);
                    screen.Children.Add(HPENEMY);

                    FRAMEENEMY1.Height = 16;
                    FRAMEENEMY1.Width = 140;
                    FRAMEENEMY1.Stroke = Brushes.Black;
                    FRAMEENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY1.Margin = new Thickness(64, 308, 0, 0);
                    screen.Children.Add(FRAMEENEMY1);

                    HPENEMY1.Height = hph;
                    HPENEMY1.Width = slime2hp;
                    HPENEMY1.Stroke = Brushes.Black;
                    HPENEMY1.Fill = Brushes.Red;
                    HPENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY1.Margin = new Thickness(64, 308, 0, 0);
                    screen.Children.Add(HPENEMY1);

                    FRAMEENEMY2.Height = 16;
                    FRAMEENEMY2.Width = 140;
                    FRAMEENEMY2.Stroke = Brushes.Black;
                    FRAMEENEMY2.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY2.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY2.Margin = new Thickness(128, 326, 0, 0);
                    screen.Children.Add(FRAMEENEMY2);

                    HPENEMY2.Height = hph;
                    HPENEMY2.Width = slime3hp;
                    HPENEMY2.Stroke = Brushes.Black;
                    HPENEMY2.Fill = Brushes.Red;
                    HPENEMY2.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY2.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY2.Margin = new Thickness(128, 326, 0, 0);
                    screen.Children.Add(HPENEMY2);
                }
            }

            if (rect.Contains(f4t5) == true && pic == 4) // из болота в замок
            {
                if (e.Key == Key.E)
                {
                    x = 300;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                    screen.Children.Remove(enemy3);
                    screen.Children.Remove(HPENEMY2);
                    screen.Children.Remove(FRAMEENEMY2);
                }
            }

            if (rect.Contains(f5t2) == true && pic == 5) // из замка на поляну
            {
                if (e.Key == Key.E)
                {
                    x = 600;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/поляна.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 2;

                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/BLYANT.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 120;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = enemyshp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(HPENEMY);
                }
            }

            if (rect.Contains(f5t3) == true && pic == 5) // из замка в лес
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/лес.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 3;

                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/loh1reverse.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);

                    enemy2.Height = 96;
                    enemy2.Width = 96;
                    ImageBrush rival1 = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival1.Stretch = Stretch.None;
                    rival1.Viewbox = new Rect(0, 0, 96, 96);
                    rival1.ViewboxUnits = BrushMappingMode.Absolute;
                    rival1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/loh2reverse.gif", UriKind.Absolute));
                    enemy2.Fill = rival1;
                    enemy2.Margin = new Thickness(446, 312, 0, 0);
                    screen.Children.Add(enemy2);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 120;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = enemyshp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(350, 296, 0, 0);
                    screen.Children.Add(HPENEMY);

                    FRAMEENEMY1.Height = 16;
                    FRAMEENEMY1.Width = 120;
                    FRAMEENEMY1.Stroke = Brushes.Black;
                    FRAMEENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY1.Margin = new Thickness(446, 278, 0, 0);
                    screen.Children.Add(FRAMEENEMY1);

                    HPENEMY1.Height = hph;
                    HPENEMY1.Width = enemyshp;
                    HPENEMY1.Stroke = Brushes.Black;
                    HPENEMY1.Fill = Brushes.Red;
                    HPENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY1.Margin = new Thickness(446, 278, 0, 0);
                    screen.Children.Add(HPENEMY1);
                }
            }

            if (rect.Contains(f6t8) == true && pic == 6) // из пещеры в сердце пещеры
            {
                if (e.Key == Key.E)
                {
                    x = 696;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/сердце пещеры2.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 8;
                    enemy.Height = 128;
                    enemy.Width = 128;
                    ImageBrush ib = new ImageBrush();
                    ib.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    ib.Stretch = Stretch.None;
                    ib.Viewbox = new Rect(0, 0, 128, 128);
                    ib.ViewboxUnits = BrushMappingMode.Absolute;
                    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/orc2.gif", UriKind.Absolute));
                    enemy.Fill = ib;
                    enemy.Margin = new Thickness(0, 280, 0, 0);
                    screen.Children.Add(enemy);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 100;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(0, 262, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = zombhp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(0, 262, 0, 0);
                    screen.Children.Add(HPENEMY);
                }
            }

            if (rect.Contains(f7t5) == true && pic == 7) // из руин к замку
            {
                if (e.Key == Key.E)
                {
                    x = 650;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/город3.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 5;
                    screen.Children.Remove(enemy);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                }
            }

            if (rect.Contains(f8t6) == true && pic == 8) // из сердца пещеры к подземелью
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/подземелье.png", UriKind.Absolute));
                    screen.Background = background;
                    pic = 6;
                    screen.Children.Remove(enemy);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                }
            }

            if (rect.Contains(f11t12) == true && pic == 11) // на корабль
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/вид с корабля.gif", UriKind.Absolute));
                    screen.Background = background;
                    pic = 12;
                    screen.Children.Remove(enemy1);
                    enemy1.Height = 96;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/PIRATE.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(350, 312, 0, 0);
                    screen.Children.Add(enemy1);
                }
            }

            Point en1 = new Point(200,312);
            Point en2 = new Point(296,312);
            Point en3 = new Point(200,216);
            Point en4 = new Point(296,216);

            Point en11 = new Point(300,312);
            Point en22 = new Point(396,312);
            Point en33 = new Point(300,216);
            Point en44 = new Point(396,216);

            if ((rect.Contains(en1) || rect.Contains(en2) || rect.Contains(en3) || rect.Contains(en4)) && pic == 14 && screen.Children.Contains(enemy1))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy1))
                {
                    en1hp = en1hp - (6 * gema.weapon);
                    if (en1hp > 0)
                        HPENEMY.Width = en1hp;
                }
            }


            if ((rect.Contains(en11) || rect.Contains(en22) || rect.Contains(en33) || rect.Contains(en44)) && pic == 14 && screen.Children.Contains(enemy2))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy2))
                {
                    en2hp = en2hp - (6 * gema.weapon);
                    if (en2hp > 0)
                        HPENEMY1.Width = en2hp;
                }
            }

            if (rect.Contains(f12t14) == true && pic == 12) // к башне
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/мб башня босса.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 14;

                    screen.Children.Remove(enemy1);

                    enemy1.Height = 92;
                    enemy1.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/enchantedsoldier1.gif", UriKind.Absolute));
                    enemy1.Fill = rival;
                    enemy1.Margin = new Thickness(200, 312, 0, 0);
                    screen.Children.Add(enemy1);

                    enemy2.Height = 96;
                    enemy2.Width = 96;
                    ImageBrush rival1 = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival1.Stretch = Stretch.None;
                    rival1.Viewbox = new Rect(0, 0, 96, 96);
                    rival1.ViewboxUnits = BrushMappingMode.Absolute;
                    rival1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/enchantedsoldier2.gif", UriKind.Absolute));
                    enemy2.Fill = rival1;
                    enemy2.Margin = new Thickness(300, 312, 0, 0);
                    screen.Children.Add(enemy2);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 200;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(150, 296, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = en1hp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(150, 296, 0, 0);
                    screen.Children.Add(HPENEMY);

                    FRAMEENEMY1.Height = 16;
                    FRAMEENEMY1.Width = 200;
                    FRAMEENEMY1.Stroke = Brushes.Black;
                    FRAMEENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY1.Margin = new Thickness(250, 278, 0, 0);
                    screen.Children.Add(FRAMEENEMY1);

                    HPENEMY1.Height = hph;
                    HPENEMY1.Width = en2hp;
                    HPENEMY1.Stroke = Brushes.Black;
                    HPENEMY1.Fill = Brushes.Red;
                    HPENEMY1.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY1.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY1.Margin = new Thickness(250, 278, 0, 0);
                    screen.Children.Add(HPENEMY1);
                }
            }

            if (rect.Contains(f14t15) == true && pic == 14) // к боссу
            {
                if (e.Key == Key.E)
                {
                    x = 0;
                    y = 216;
                    background.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/текстурки/сердце пещеры.jpg", UriKind.Absolute));
                    screen.Background = background;
                    pic = 15;
                    screen.Children.Remove(enemy1);
                    screen.Children.Remove(HPENEMY);
                    screen.Children.Remove(FRAMEENEMY);
                    screen.Children.Remove(enemy2);
                    screen.Children.Remove(HPENEMY1);
                    screen.Children.Remove(FRAMEENEMY1);
                    enemy.Height = 96;
                    enemy.Width = 96;
                    ImageBrush rival = new ImageBrush();
                    rival.AlignmentX = AlignmentX.Left;
                    //ib.AlignmentY = AlignmentY.Top;
                    rival.Stretch = Stretch.None;
                    rival.Viewbox = new Rect(0, 0, 96, 96);
                    rival.ViewboxUnits = BrushMappingMode.Absolute;
                    rival.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/poses/GOLIY.gif", UriKind.Absolute));
                    enemy.Fill = rival;
                    enemy.Margin = new Thickness(696, 312, 0, 0);
                    screen.Children.Add(enemy);

                    FRAMEENEMY.Height = 16;
                    FRAMEENEMY.Width = 300;
                    FRAMEENEMY.Stroke = Brushes.Black;
                    FRAMEENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    FRAMEENEMY.VerticalAlignment = VerticalAlignment.Center;
                    FRAMEENEMY.Margin = new Thickness(0, 0, 0, 0);
                    screen.Children.Add(FRAMEENEMY);

                    HPENEMY.Height = hph;
                    HPENEMY.Width = wizardshp;
                    HPENEMY.Stroke = Brushes.Black;
                    HPENEMY.Fill = Brushes.Red;
                    HPENEMY.HorizontalAlignment = HorizontalAlignment.Left;
                    HPENEMY.VerticalAlignment = VerticalAlignment.Center;
                    HPENEMY.Margin = new Thickness(0, 0, 0, 0);
                    screen.Children.Add(HPENEMY);
                }
            }

            Point e111 = new Point(696, 312);
            Point e222 = new Point(792, 312);
            Point e333 = new Point(696, 248);
            Point e444= new Point(792, 248);

            if ((rect.Contains(e111) || rect.Contains(e222) || rect.Contains(e333) || rect.Contains(e444)) && pic == 15 && screen.Children.Contains(enemy))
            {
                FightTimer.Start();
                if (e.Key == Key.A && screen.Children.Contains(enemy))
                {
                    wizardshp = wizardshp - (6 * gema.weapon);
                    if (wizardshp > 0)
                        HPENEMY.Width = wizardshp;
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }


    }
}