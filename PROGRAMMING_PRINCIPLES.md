# Принципи програмування у проєкті SnakeGameWPF

### 1. DRY (Don't Repeat Yourself)
**Опис:** Принцип спрямований на уникнення дублювання коду. У моєму проєкті логіка запуску нової гри винесена в окремий метод `StartNewGame()`, який викликається і при першому старті, і при рестарті.
**Код:** [MainWindow.xaml.cs L48-63](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/WpfApp1/MainWindow.xaml.cs)

### 2. KISS (Keep It Simple, Stupid)
**Опис:** Намагання зробити код максимально простим. Клас `Food` містить лише необхідні координати без зайвої складності.
**Код:** [Food.cs](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/WpfApp1/Food.cs)

### 3. Encapsulation (Інкапсуляція)
**Опис:** Стан гри (Score, IsGameOver) закритий для прямої зміни ззовні через використання властивостей з приватними сеттерами.
**Код:** [GameEngine.cs](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/WpfApp1/GameEngine.cs)
