SnakeGame

Prosta implementacja gry Snake w C#, działająca bezpośrednio w oknie konsoli.
Jak uruchomić

Wystarczy skompilować plik Snake.cs w dowolnym środowisku obsługującym C# (Visual Studio, VS Code, czy zwykły csc z wiersza poleceń).

Wymagania:

    .NET Framework lub .NET Core/5+

    System Windows (ze względu na użycie Console.WindowHeight/Width)

Sterowanie

Gra obsługiwana jest wyłącznie klawiaturą:

    Strzałka W Górę – Ruch w górę

    Strzałka W Dół – Ruch w dół

    Strzałka W Lewo – Ruch w lewo

    Strzałka W Prawo – Ruch w prawo

Zasady gry

    Sterujesz zielonym wężem (■).

    Celem jest zbieranie "owoców" oznaczonych jako *.

    Każdy zebrany owoc zwiększa wynik i długość węża.

    Gra kończy się, gdy uderzysz w białą ramkę lub we własny ogon.

Uwagi do kodu

    Rozmiar okna konsoli jest ustawiony na sztywno (32x18 znaków).

    Prędkość gry jest stała (pętla z Thread.Sleep(150)).