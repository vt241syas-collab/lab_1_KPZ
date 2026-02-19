# Принципи програмування у проєкті SnakeGameWPF

1. DRY (Don't Repeat Yourself)
Принцип спрямований на уникнення дублювання коду. У моєму проєкті логіка запуску нової гри винесена в окремий метод `StartNewGame()`, який викликається і при першому старті, і при рестарті.
[MainWindow.xaml.cs L48-63](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/MainWindow.xaml.cs)

2. KISS (Keep It Simple, Stupid)
Намагання зробити код максимально простим. Клас `Food` містить лише необхідні координати без зайвої складності.
[Food.cs](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/Food.cs)

3. Encapsulation (Інкапсуляція)
Стан гри (Score, IsGameOver) закритий для прямої зміни ззовні через використання властивостей з приватними сеттерами.
[GameEngine.cs L13-14](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/GameEngine.cs)