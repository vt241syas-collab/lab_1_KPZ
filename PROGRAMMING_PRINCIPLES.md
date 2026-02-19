# Принципи програмування у проєкті SnakeGameWPF

### 1. DRY (Don't Repeat Yourself)
**Опис:** Принцип спрямований на уникнення дублювання коду. У моєму проєкті логіка запуску нової гри винесена в окремий метод `StartNewGame()`, який викликається і при першому старті, і при рестарті.
**Код:** [MainWindow.xaml.cs L48-63](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/MainWindow.xaml.cs)

### 2. KISS (Keep It Simple, Stupid)
**Опис:** Клас Food реалізований максимально просто.
**Код:** [Food.cs](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/Food.cs)

### 3. Encapsulation (Інкапсуляція)
**Опис:** Використання властивостей з приватними сеттерами у GameEngine.
**Код:** [GameEngine.cs](https://github.com/vt241syas-collab/lab_1_KPZ/blob/main/GameEngine.cs)
