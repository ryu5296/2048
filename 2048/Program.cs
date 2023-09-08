var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


void Drawing()
{
    int square = fieldView.Width / EDGE;

    // PictureBox
    Bitmap canvas = new Bitmap(fieldView.Width, fieldView.Height);
    Graphics g = Graphics.FromImage(canvas);

    for (int i = 0; i < EDGE; i++)
    {
        for (int j = 0; j < EDGE; j++)
        {
            Color color;
            switch (field[i, j])
            {
                case 0:
                    color = Color.FromArgb(205, 192, 180);
                    break;
                case 2:
                    color = Color.FromArgb(238, 228, 218);
                    break;
                case 4:
                    color = Color.FromArgb(237, 224, 200);
                    break;
                case 8:
                    color = Color.FromArgb(242, 177, 121);
                    break;
                case 16:
                    color = Color.FromArgb(245, 149, 99);
                    break;
                case 32:
                    color = Color.FromArgb(247, 123, 94);
                    break;
                case 64:
                    color = Color.FromArgb(246, 94, 59);
                    break;
                case 128:
                    color = Color.FromArgb(237, 207, 115);
                    break;
                case 256:
                    color = Color.FromArgb(237, 204, 98);
                    break;
                case 512:
                    color = Color.FromArgb(237, 200, 80);
                    break;
                case 1024:
                    color = Color.FromArgb(237, 197, 63);
                    break;
                case 2048:
                    color = Color.FromArgb(237, 194, 45);
                    break;
                default:
                    color = Color.FromArgb(255, 134, 1);
                    break;
            }
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, j * square, i * square, square, square);
            brush.Dispose();
            if (field[i, j] > 0)
            {
                Font font = new Font("Consolas", 20, FontStyle.Bold);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                Brush b = Brushes.DimGray;
                g.DrawString(field[i, j].ToString(), font, b, j * square + square / 2, i * square + square / 2, sf);
            }
        }
    }

    // 線
    for (int i = 1; i < EDGE; i++)
    {
        g.DrawLine(Pens.LightGray, square * i, 0, square * i, fieldView.Height);
        g.DrawLine(Pens.LightGray, 0, square * i, fieldView.Height, square * i);
    }

    g.Dispose();
    fieldView.Image = canvas;
}