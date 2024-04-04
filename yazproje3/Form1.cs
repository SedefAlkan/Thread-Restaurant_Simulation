using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazproje3
{
    public partial class Form1 : Form
    {
        private int totalCustomers = 0;
        private int paidCustomers = 0;
        private string[] customerImages = { @"C:\Users\ASUS\OneDrive\Masaüstü\yasli.jpg", @"C:\Users\ASUS\OneDrive\Masaüstü\genckiz.png", @"C:\Users\ASUS\OneDrive\Masaüstü\gencerkek.png", @"C:\Users\ASUS\OneDrive\Masaüstü\ortakadin.png" };
        private string customerSitImage = @"C:\Users\ASUS\OneDrive\Masaüstü\transparent-cafe-restaurant-cartoon-customer-waiter-5eb9c684a0db33.3336744615892332846589.jpg"; // Yeni müşteri oturduğunda kullanılacak resim dosya yolu
        private Random random = new Random();
        private int customerCount = 0;
        private int maxCustomerCount = 0;
        private System.Windows.Forms.Timer customerTimer;
        private List<PictureBox> customers = new List<PictureBox>();

        private List<PictureBox> tables = new List<PictureBox>(); // Masaları temsil eden PictureBox'ların listesi

        private NumericUpDown customerCountSelector; // Kullanıcı tarafından belirlenecek müşteri sayısını seçmek için NumericUpDown nesnesi

        public Form1()
        {
            InitializeComponent();

            // Load the image into a variable
            Image image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\png-transparent-cartoon-table-furniture-happy-birthday-vector-images-wooden-table.png");

            // Assign the image to each PictureBox control
            Masa1.Image = image;
            Masa2.Image = image;
            Masa3.Image = image;
            Masa4.Image = image;
            Masa5.Image = image;
            Masa6.Image = image;
            garson1picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            garson2picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            garson3picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            garson1picturebox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\garson1.jpg");
            garson2picturebox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\garson2.jpg");
            garson3picturebox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\garson3.png");
            asci1pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            asci2pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            mutfakpictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            asci1pictureBox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\ascı1.jpg");
            asci2pictureBox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\ascı2.jpg");
            mutfakpictureBox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\mutfak2.jpg");
            kasapictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            kasapictureBox.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\kasa.jpg");

            // Set PictureBox controls' SizeMode property to fit the image into the box
            Masa1.SizeMode = PictureBoxSizeMode.Zoom;
            Masa2.SizeMode = PictureBoxSizeMode.Zoom;
            Masa3.SizeMode = PictureBoxSizeMode.Zoom;
            Masa4.SizeMode = PictureBoxSizeMode.Zoom;
            Masa5.SizeMode = PictureBoxSizeMode.Zoom;
            Masa6.SizeMode = PictureBoxSizeMode.Zoom;

            // PictureBox'lara Click olaylarını ekleme
            Masa1.Click += PictureBox_Click;
            Masa2.Click += PictureBox_Click;
            Masa3.Click += PictureBox_Click;
            Masa4.Click += PictureBox_Click;
            Masa5.Click += PictureBox_Click;
            Masa6.Click += PictureBox_Click;

            // Masaları listeye ekle
            tables.Add(Masa1);
            tables.Add(Masa2);
            tables.Add(Masa3);
            tables.Add(Masa4);
            tables.Add(Masa5);
            tables.Add(Masa6);

            // Müşteri sayısını belirlemek için bir NumericUpDown oluştur
            customerCountSelector = new NumericUpDown();
            customerCountSelector.Minimum = 1; // Minimum müşteri sayısı
            customerCountSelector.Maximum = 50; // Maximum müşteri sayısı
            customerCountSelector.Location = new Point(1050, 10); // NumericUpDown kontrolünün konumu
            customerCountSelector.ValueChanged += CustomerCountSelector_ValueChanged; // Değer değiştiğinde gerçekleşecek olay

            this.Controls.Add(customerCountSelector); // Değer değiştiğinde gerçekleşecek olay

            this.Controls.Add(customerCountSelector); // Form'a NumericUpDown kontrolünü ekle

            // Müşterileri belirli aralıklarla ekleyen bir Timer oluşturma
            customerTimer = new System.Windows.Forms.Timer();
            customerTimer.Interval = 2000; // 2 saniye
            customerTimer.Tick += CustomerTimer_Tick;
            customerTimer.Start();
        }

        private async void CustomerTimer_Tick(object sender, EventArgs e)
        {
            if (customerCount < maxCustomerCount)
            {
                AddCustomer();
            }
            else
            {
                customerTimer.Stop();
                await Task.Delay(2000);
               // Tüm müşteriler geldikten sonra 2 saniye bekleyin

            }
        }



        private void PictureBox_Click(object sender, EventArgs e)
        {
            
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null)
            {
                
                MessageBox.Show("PictureBox " + clickedPictureBox.Name + " tıklandı!");
                
            }
        }

        private void AddCustomer()
        {
            // Özel resmin yolu
            string yasliPath = @"C:\Users\ASUS\OneDrive\Masaüstü\yasli.jpg";

            if (customerCount < maxCustomerCount)
            {
                PictureBox customerPictureBox = new PictureBox();
                customerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                customerPictureBox.Width = 80;
                customerPictureBox.Height = 80;
                customerPictureBox.Tag = "Customer";
                customerPictureBox.BorderStyle = BorderStyle.FixedSingle;

                int columnCount = 2; 
                int yPos = customerCount / columnCount * 90;
                int xPos = (customerCount % columnCount) * 90;

                // Rastgele bir resim seç
                int imageIndex = random.Next(customerImages.Length);
                string selectedImagePath = customerImages[imageIndex];

                // Resmin dosya yolunu kontrol et
                if (selectedImagePath == yasliPath)
                {
                    // Eğer seçilen resim yasliPath'e eşitse, resmi önceki müşterilerin önüne ekle
                    customerPictureBox.Image = Image.FromFile(selectedImagePath);
                    customers.Insert(0, customerPictureBox); // Özel resmi ilk sıraya ekle
                }
                else
                {
                    // Diğer müşterileri listenin devamına ekle
                    customerPictureBox.Image = Image.FromFile(selectedImagePath);
                    customers.Add(customerPictureBox);
                }


                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        customerPictureBox.Location = new Point(xPos, yPos);
                        panel2.Controls.Add(customerPictureBox);
                    });
                }
                else
                {
                    customerPictureBox.Location = new Point(xPos, yPos);
                    panel2.Controls.Add(customerPictureBox);
                }

                customerCount++;

                if (customerCount == maxCustomerCount) 
                {
                    Thread assignThread = new Thread(new ThreadStart(AssignCustomersToTables)); 
                    assignThread.Start();
                    int panel1Index = 0;

                    // Müşterileri panel2'den al
                    List<PictureBox> customersFromPanel2 = customers.Skip(6).ToList();

                    foreach (PictureBox customerFromPanel2 in customersFromPanel2)
                    {
                        // Müşteriyi panel1'e ekleme
                        if (this.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                panel1.Controls.Add(customerFromPanel2);
                                panel1.Controls.SetChildIndex(customerFromPanel2, panel1Index);
                            });
                        }
                        else
                        {
                            panel1.Controls.Add(customerFromPanel2);
                            panel1.Controls.SetChildIndex(customerFromPanel2, panel1Index); 
                        }

                        panel1Index++; 
                    }
                }
            }
        }
     

        private void CheckAndAssignCustomersToTables()
        {
            foreach (PictureBox table in tables)
            {
                if (table.Tag != null && table.Tag.ToString() == "Empty")
                {
                    // Masanın boş olduğunu kontrol et
                    if (panel1.Controls.Count > 0)
                    {
                        PictureBox waitingCustomer = panel1.Controls[0] as PictureBox;

                        if (waitingCustomer != null)
                        {
                            table.Image = Image.FromFile(customerSitImage);
                            table.Tag = "Occupied";
                            waitingCustomer.Tag = table.Name;

                           

                            if (this.InvokeRequired)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    panel1.Controls.Remove(waitingCustomer); // Bekleyen müşteriyi panel1'den kaldır
                                   // panel2.Controls.Add(waitingCustomer); // Müşteriyi masaya oturt
                                });
                            }
                            else
                            {
                                panel1.Controls.Remove(waitingCustomer); // Bekleyen müşteriyi panel1'den kaldır
                              //  panel2.Controls.Add(waitingCustomer); // Müşteriyi masaya oturt
                            }
                        }

                    }
                    

                }

               
            }
        }


        private void CustomerCountSelector_ValueChanged(object sender, EventArgs e)
        {
            int selectedValue = (int)customerCountSelector.Value;

            if (selectedValue > 10)
            {
                MessageBox.Show("Maksimum müşteri sayısı 10 olabilir!");
                customerCountSelector.Value = totalCustomers; 
            }
            else
            {
                maxCustomerCount = selectedValue;

                if (maxCustomerCount != totalCustomers) 
                {
                    customers.Clear(); 
                    customerCount = 0;
                    totalCustomers = maxCustomerCount; 
                }

                
                if (maxCustomerCount > 0 && customerTimer != null && !customerTimer.Enabled)
                {
                    // Yeni müşterilerin gelmesi için bir thread oluştur ve başlat
                    Thread startNewCustomersThread = new Thread(StartNewCustomers);
                    startNewCustomersThread.Start();
                }
            }
        }


        private void StartNewCustomers()
        {
            // Yeni müşteri eklenmesi gereken durumda
            while (customerCount < maxCustomerCount)
            {
                AddCustomer();
                Thread.Sleep(2000); // 2 saniye aralıklarla müşteri ekle
            }
        }



        private bool tablesFull = false; 

        private async void AssignCustomersToTables()
        {
            List<PictureBox> customersToBeRemoved = new List<PictureBox>();

            foreach (PictureBox customerPictureBox in customers)
            {
                bool tableFound = false;

                foreach (PictureBox table in tables)
                {
                    if (table.Tag == null || table.Tag.ToString() == "Empty")
                    {
                        table.Image = Image.FromFile(customerSitImage);
                        table.Tag = "Occupied";
                        customerPictureBox.Tag = table.Name;
                        tableFound = true;
                        customersToBeRemoved.Add(customerPictureBox);
                       
                        break; // Müşteriyi masaya yerleştirdikten sonra döngüden çık
                    }
                }

                if (!tableFound)
                {
                    MessageBox.Show("Tüm masalar dolu!");
                   
                    break; 
                }
            }
            


            
            foreach (PictureBox customerToRemove in customersToBeRemoved)
            {
                if (panel2.InvokeRequired)
                {
                    panel2.Invoke(new MethodInvoker(delegate
                    {
                        customers.Remove(customerToRemove);
                        if (panel2.Controls.Contains(customerToRemove))
                        {
                            panel2.Controls.Remove(customerToRemove);
                        }
                    }));
                }
                else
                {
                    customers.Remove(customerToRemove);
                    if (panel2.Controls.Contains(customerToRemove))
                    {
                        panel2.Controls.Remove(customerToRemove);
                    }
                }
            }

            // Geri kalan müşterileri de masalara yerleştir
            for (int i = 6; i < customers.Count; i++)
            {
                PictureBox customerPictureBox = customers[i];

                foreach (PictureBox table in tables)
                {
                    if (table.Tag == null || table.Tag.ToString() == "Empty")
                    {
                        table.Image = Image.FromFile(customerSitImage);
                        table.Tag = "Occupied";
                        customerPictureBox.Tag = table.Name;
                        customersToBeRemoved.Add(customerPictureBox);
                        break; // Müşteriyi masaya yerleştirdikten sonra döngüden çık
                    }
                }
            }

          
            foreach (PictureBox customerToRemove in customersToBeRemoved)
            {
                if (panel2.InvokeRequired)
                {
                    panel2.Invoke(new MethodInvoker(delegate
                    {
                        customers.Remove(customerToRemove);
                        if (panel2.Controls.Contains(customerToRemove))
                        {
                            panel2.Controls.Remove(customerToRemove);
                        }
                    }));
                }
                else
                {
                    customers.Remove(customerToRemove);
                    if (panel2.Controls.Contains(customerToRemove))
                    {
                        panel2.Controls.Remove(customerToRemove);
                    }
                }
            }

           
            await Task.Delay(4000); // 4 saniye bekleme
           
            // Garsonların sipariş almasını sağlama
            await Task.Run(() => TakeOrders());

            // Aşçıların siparişleri hazırlamasını sağlama
            List<Task> chefTasks = new List<Task>();

            Task chef1Task = Task.Run(() => ChefProcessOrders(1));
            Task chef2Task = Task.Run(() => ChefProcessOrders(2));

            chefTasks.Add(chef1Task);
            chefTasks.Add(chef2Task);

            await Task.WhenAll(chefTasks);
        }

    

    private async void CheckCustomerPayment()
        {

            foreach (PictureBox table in tables)
            {
                if (table.Tag != null && table.Tag.ToString() == "Occupied")
                {

                    
                    if (System.IO.File.Exists(@"C:\Users\ASUS\OneDrive\Masaüstü\yemekhazir.jpg"))
                    {
                        if (table.Image != null)
                        {
                            Bitmap bitmap = new Bitmap(table.Image);
                            Bitmap yemekHazir = new Bitmap(@"C:\Users\ASUS\OneDrive\Masaüstü\yemekhazir.jpg");

                            if (ImagesAreEqual(bitmap, yemekHazir))
                            {
                                // Eğer masada yemek hazır fotoğrafı varsa, o masayı ücreti ödendi olarak işaretle
                                await Task.Delay(3000);
                                table.Tag = "Empty";
                                listBox4.Items.Add($"Ücreti Ödendi Masa: {table.Name}");
                                table.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\png-transparent-cartoon-table-furniture-happy-birthday-vector-images-wooden-table.png");
                                await Task.Delay(2000);
                                 CheckAndAssignCustomersToTables();
                                // Yeni müşterilerin gelmesi için bir thread oluştur ve başlat
                              



                            }

                        }
                    }
                    else
                    {
                       
                        MessageBox.Show("Resim dosyası bulunamadı veya yol hatalı.");
                    }
                }
            }
            paidCustomers++;

            // Tüm müşterilerin ödemesi tamamlandıysa
            if (paidCustomers == totalCustomers)
            {
                await Task.Delay(3000); 

                if (panel1.InvokeRequired)
                {
                    panel1.Invoke(new MethodInvoker(delegate
                    {
                        panel1.Controls.Clear();
                    }));
                }
                else
                {
                    panel1.Controls.Clear(); 
                }
            }
        }

        private bool AllTablesPaid()
        {
            foreach (PictureBox table in tables)
            {
                if (table.Tag == null || table.Tag.ToString() != "Empty")
                {
                    return false;
                }
            }
            return true;
        }
       
        private bool ImagesAreEqual(Bitmap img1, Bitmap img2)
        {
            if (img1.Width != img2.Width || img1.Height != img2.Height)
            {
                return false;
            }

            for (int x = 0; x < img1.Width; x++)
            {
                for (int y = 0; y < img1.Height; y++)
                {
                    if (img1.GetPixel(x, y) != img2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }



        private async void ChefProcessOrders(int chefNumber)
        {
            int tableIndex = chefNumber - 1; // Aşçı numarası ile table dizisi indeksi arasındaki ilişki
            int maxTables = 6;

            while (tableIndex < maxTables)
            {
                PictureBox table = tables[tableIndex];

                if (table.Tag != null && table.Tag.ToString() == "Occupied")
                {
                   
                    DisplayOrderMessage(chefNumber, table.Name);

                   
                    Task task1 = Task.Run(async () =>
                    {
                        // Sipariş hazırlanıyor işareti gösterme (örnek resim yolu)
                        DisplayPreparingOrderImage(table);

                        // Siparişin hazırlanma süresi (simülasyon için 10 saniye)
                        await Task.Delay(10000); // Siparişin hazırlanma süresi

                        // Sipariş hazırlandı görsel gösterimi
                        DisplayOrderReadyImage(table);

                    });

                    
                    await task1;


                   
                }

                tableIndex += 2; 
            }
        }


        private void DisplayOrderMessage(int chefNumber, string tableName)
        {
           
            switch (chefNumber)
            {
                case 1:
                    listBox1.Invoke((MethodInvoker)async delegate
                    {
                        asci1listBox.Items.Add($"Siparişi Hazırlıyor: {tableName}");

                        await Task.Delay(10000); 

                        asci1listBox.Items.Add($"Siparişi Hazırlandı: {tableName}");
                    });
                    break;
                case 2:
                    listBox2.Invoke((MethodInvoker)async delegate
                    {
                        asci2listBox.Items.Add($"Siparişi Hazırlıyor: {tableName}");

                        await Task.Delay(10000); 

                        asci2listBox.Items.Add($"Siparişi Hazırlandı: {tableName}");
                    });
                    break;
                default:
                    break;
            }
        }

        private void DisplayPreparingOrderImage(PictureBox table)
        {
            
            if (table.InvokeRequired)
            {
                table.Invoke((MethodInvoker)delegate
                {
                    table.Image = null; // Önceki resmi kaldırma
                    table.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\hazirlaniyor.jpg"); 
                });
            }
            else
            {
                table.Image = null; // Önceki resmi kaldırma
                table.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\hazirlaniyor.jpg");
            }
        }

        private void DisplayOrderReadyImage(PictureBox table)
        {
            
            if (table.InvokeRequired)
            {
                table.Invoke((MethodInvoker)delegate
                {
                    table.Image = null; // Önceki resmi kaldırma
                    table.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\yemekhazir.jpg"); 
                    CheckCustomerPayment();

                });
            }
            else
            {
                table.Image = null; // Önceki resmi kaldırma
                table.Image = Image.FromFile(@"C:\Users\ASUS\OneDrive\Masaüstü\yemekhazir.jpg");
            }


        }
       
        private void TakeOrders()
        {
            Task garson1Task = Task.Run(() => GarsonOrderProcess(1));
            Task garson2Task = Task.Run(() => GarsonOrderProcess(2));
            Task garson3Task = Task.Run(() => GarsonOrderProcess(3));

            Task.WaitAll(garson1Task, garson2Task, garson3Task);
        }

        private async void GarsonOrderProcess(int garsonNumber)
        {
            int garsonIndex = garsonNumber - 1;
            int maxTables = 6; // Toplam masa sayısı
            int orderCount = 0; // Sipariş sayısını takip etmek için sayaç

            while (garsonIndex < maxTables)
            {
                PictureBox table = tables[garsonIndex];

                if (table.Tag != null && table.Tag.ToString() == "Occupied")
                {
                    string siparisFoto = @"C:\Users\ASUS\OneDrive\Masaüstü\siparis1.jpg";

                    switch (garsonNumber)
                    { 
                     case 1:
                        listBox1.Invoke((MethodInvoker)async delegate
                        {
                            listBox1.Items.Add("Sipariş Alıyor:" + table.Name);

                            await Task.Delay(2000); 

                            listBox1.Items.Add("Sipariş Alındı:" + table.Name);
                        });
                        break;
                    case 2:
                        listBox2.Invoke((MethodInvoker)async delegate
                        {
                            listBox2.Items.Add("Sipariş Alıyor:" + table.Name);

                            await Task.Delay(2000); 

                            listBox2.Items.Add("Sipariş Alındı:" + table.Name);
                        });
                        break;
                    case 3:
                        listBox3.Invoke((MethodInvoker)async delegate
                        {
                            listBox3.Items.Add("Sipariş Alıyor:" + table.Name);

                            await Task.Delay(2000); 

                            listBox3.Items.Add("Sipariş Alındı:" + table.Name);
                        });
                        break;
                    default:
                        break;
                    }

                    if (table.InvokeRequired)
                    {
                        table.Invoke((MethodInvoker)delegate
                        {
                            table.Image = null;
                            table.Image = Image.FromFile(siparisFoto);
                        });
                    }
                    else
                    {
                        table.Image = null;
                        table.Image = Image.FromFile(siparisFoto);
                    }

                    await Task.Delay(5000); 

                    orderCount++; // Sipariş sayısını bir artır

                    if (orderCount >= 2) // Aşçının 2 siparişi aldığını kontrol et
                        break; 

                    // Aşçı 2 sipariş aldıktan sonra diğer masalardan sipariş almaya geç

                    for (int i = garsonIndex + 3; i < maxTables; i += 3) // Diğer masalardan sipariş almaya devam et
                    {
                        PictureBox nextTable = tables[i];

                        if (nextTable.Tag != null && nextTable.Tag.ToString() == "Occupied")
                        {
                           
                            string nextSiparisFoto = @"C:\Users\ASUS\OneDrive\Masaüstü\siparis1.jpg";

                            if (nextTable.InvokeRequired)
                            {
                                nextTable.Invoke((MethodInvoker)delegate
                                {
                                    nextTable.Image = null;
                                    nextTable.Image = Image.FromFile(nextSiparisFoto);
                                });
                            }
                            else
                            {
                                nextTable.Image = null;
                                nextTable.Image = Image.FromFile(nextSiparisFoto);
                            }
                        }
                    }
                }

                garsonIndex += 3; // Her garson her 3 masaya bakacak şekilde indeksi artırma
                Thread.Sleep(1000);
              


            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void garson1picturebox_Click(object sender, EventArgs e)
        {

        }

        private void garson2picturebox_Click(object sender, EventArgs e)
        {

        }

        private void garson3picturebox_Click(object sender, EventArgs e)
        {

        }

        private void mutfakpictureBox_Click(object sender, EventArgs e)
        {

        }

        private void asci1pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void asci2pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void kasapictureBox_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void asci1listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void asci2listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}