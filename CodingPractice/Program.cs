using System;

{
    Console.WriteLine("\n===========================");

    Notify notify = null;

    notify += SayHello;
    notify += SayGoodbye;

    notify();


    void SayHello()
    {
        Console.WriteLine("안녕하세요!");
    }

    void SayGoodbye()
    {
        Console.WriteLine("안녕히가세요!");
    }
}

{
    Console.WriteLine("\n===========================");

    Button button = new Button();

    button.Click += HandleClick;
    button.Click += HandleClickAgain;

    button.OnClick();


    void HandleClick()
    {
        Console.WriteLine("버튼이 클릭되었습니다!");
    }

    void HandleClickAgain()
    {
        Console.WriteLine("클릭 처리 완료");
    }
}

{
    Console.WriteLine("\n===========================");

    Player player = new Player();
    HealthBar healthBar = new HealthBar();
    SoundManager soundManager = new SoundManager();

    player.DamageTaken += healthBar.OnPlayerDamaged;
    player.DamageTaken += soundManager.OnPlayerDamaged;

    player.TakeDamage(30);
}

{
    Console.WriteLine("\n===========================");

    Timer timer = new Timer();
    Logger logger = new Logger();


    Console.WriteLine("=== 구독 상태 ===");
    timer.Tick += logger.Log;
    timer.Start();

    Console.WriteLine("\n=== 구독 해제 후 ===");

    timer.Tick -= logger.Log;
    timer.Start();
}

{
    Console.WriteLine("\n===========================");

    Sensor sensor = new Sensor();

    sensor.Alert += (msg) => Console.WriteLine($"[경보] {msg}");
    sensor.Alert += (msg) => Console.WriteLine($"[로그] {DateTime.Now}: {msg}");

    sensor.Detect("움직임 감지됨");
    sensor.Detect("온도 상승");
}

{
    Console.WriteLine("\n===========================");

    GameCharacter hero = new GameCharacter("용사", 100);

    hero.OnDeath += () => Console.WriteLine("캐릭터가 사망했습니다");
    hero.OnDamaged += damage => { hero.Health -= damage; Console.WriteLine($"남은 체력: {hero.Health}"); };
    hero.OnAttack += (damage, name) => Console.WriteLine($"{name}에게 {50}데미지!");

    hero.DoAttack("슬라임", 50);
    hero.TakeDamage(30);
    hero.TakeDamage(80);
}

{
    Console.WriteLine("\n===========================");

    Stock stock = new Stock
    {
        Name = "MSFT",
        Price = 100
    };

    stock.PriceChanged += (stock, priceChanged) =>
    {
        if (stock is Stock s)
        { 
            Console.WriteLine($"[{s.Name}: W{priceChanged.NewPrice}]");
            Console.WriteLine($"  이전 가격: W{priceChanged.OldPrice}");
            Console.WriteLine($"  현재 가격: W{priceChanged.NewPrice}");
            Console.WriteLine($"  변동률: {priceChanged.ChangePercent:F2}%\n");
        }
    };

    stock.ChangePrice(110);
    stock.ChangePrice(105.50);
    stock.ChangePrice(120);
}

{
    Console.WriteLine("\n===========================");

    Car car = new Car();
    Dashboard dashboard = new Dashboard();

    
    car.FuelLow += (car, fuelArgs) =>
    {
        if (car is Car c)
        {
            if (c.Fuel > 0)
            {
                Console.WriteLine($"[경고!] 연료가 부족합니다 (잔량: {c.Fuel}%)");
            }
            else
            {
                c.Fuel = 0;
                Console.WriteLine($"[경고!] 연료가 바닥났습니다! (잔량: 0%)");
            }
        }
    };
    car.FuelChanged += dashboard.PrintFuelGauge;


    for (int i = 0; i < 7; i++)
    {
        car.Drive();
        Console.WriteLine();
    }
}

{
    Console.WriteLine("\n===========================");

    SecurePublisher publisher = new SecurePublisher();

    publisher.MyEvent += Handler1;
    publisher.MyEvent += Handler2;

    Console.WriteLine("\n이벤트 발생:");
    publisher.RaiseEvent();

    Console.WriteLine();
    publisher.MyEvent -= Handler1;

    Console.WriteLine("\n이벤트 발생:");
    publisher.RaiseEvent();


    void Handler1(object sender, EventArgs e)
    {
        Console.WriteLine("Handler1 실행됨");
    }

    void Handler2(object sender, EventArgs e)
    {
        Console.WriteLine("Handler2 실행됨");
    }
}

{
    Console.WriteLine("\n===========================");

    Module1 module1 = new Module1();
    Module2 module2 = new Module2();

    GlobalNotifier.SendMessage("시스템 시작");
    Console.WriteLine();
    GlobalNotifier.SendMessage("데이터 로드 완료");
}

delegate void Notify();