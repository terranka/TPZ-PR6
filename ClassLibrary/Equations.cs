namespace TPZ_PR4
{
    /// <summary>
    /// Представляє лінійну функцію вигляду y = kx + b (Варіант 4).
    /// </summary>
    public class LinearEquation
    {
        /// <summary> Отримує або задає кутовий коефіцієнт прямої. </summary>
        public double K { get; set; }

        /// <summary> Отримує або задає вільний член (перетин з віссю Oy). </summary>
        public double B { get; set; }

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="LinearEquation"/>.
        /// </summary>
        /// <param name="k">Кутовий коефіцієнт k.</param>
        /// <param name="b">Вільний член b.</param>
        public LinearEquation(double k, double b)
        {
            K = k;
            B = b;
        }

        /// <summary>
        /// Обчислює значення лінійної функції у точці x.
        /// Застосовано рефакторинг: Inline Temp.
        /// </summary>
        /// <param name="x">Значення аргументу x.</param>
        /// <returns>Значення функції y = kx + b.</returns>
        public double Calculate(double x) => K * x + B;

        /// <summary>
        /// Знаходить корінь лінійного рівняння kx + b = 0.
        /// Застосовано рефакторинг: Replace Nested Conditional with Guard Clauses.
        /// </summary>
        /// <param name="root">Вихідний знайдений корінь.</param>
        /// <param name="error">Повідомлення про помилку у разі неможливості розв'язання.</param>
        /// <returns>True, якщо корінь знайдено успішно; інакше false.</returns>
        public bool FindRoot(out double root, out string error)
        {
            root = double.NaN;

            // Guard Clause 1: Перевірка виродженого випадку
            if (Math.Abs(K) < 1e-9)
            {
                error = Math.Abs(B) < 1e-9 
                    ? "Рівняння має безліч розв'язків (0 = 0)." 
                    : "Рівняння не має розв'язків (пряма паралельна осі Ox).";
                return false;
            }

            // Основний лінійний потік
            root = -B / K;
            error = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Представляє квадратичну функцію вигляду y = ax^2 + bx + c (Варіант 4).
    /// </summary>
    public class QuadraticEquation
    {
        /// <summary> Старший коефіцієнт при x^2. </summary>
        public double A { get; set; }

        /// <summary> Коефіцієнт при x. </summary>
        public double B { get; set; }

        /// <summary> Вільний член. </summary>
        public double C { get; set; }

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="QuadraticEquation"/>.
        /// </summary>
        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Обчислює дискримінант квадратичного рівняння: D = b^2 - 4ac.
        /// Застосовано рефакторинг: Inline Temp.
        /// </summary>
        public double Discriminant() => B * B - 4 * A * C;

        /// <summary>
        /// Обчислює значення квадратичної функції у точці x.
        /// Застосовано рефакторинг: Inline Temp.
        /// </summary>
        public double Calculate(double x) => A * x * x + B * x + C;

        /// <summary>
        /// Знаходить корені квадратичного рівняння ax^2 + bx + c = 0.
        /// Застосовано рефакторинг: Replace Nested Conditional with Guard Clauses (усунення вкладеності).
        /// </summary>
        /// <param name="root1">Перший знайдений корінь.</param>
        /// <param name="root2">Другий знайдений корінь.</param>
        /// <param name="error">Повідомлення про помилку у разі відсутності розв'язків.</param>
        /// <returns>Кількість дійсних коренів (0, 1 або 2).</returns>
        public int FindRoots(out double root1, out double root2, out string error)
        {
            root1 = double.NaN;
            root2 = double.NaN;

            // Guard Clause 1: Перевірка на старший коефіцієнт a
            if (Math.Abs(A) < 1e-9)
            {
                error = "Коефіцієнт a = 0. Рівняння вироджується у лінійне!";
                return 0;
            }

            double d = Discriminant();

            // Guard Clause 2: Від'ємний дискримінант
            if (d < 0)
            {
                error = $"Дискримінант D = {d:F2} < 0. Дійсних коренів не існує.";
                return 0;
            }

            // Guard Clause 3: Нульовий дискримінант (один корінь)
            if (Math.Abs(d) < 1e-9)
            {
                root1 = -B / (2 * A);
                root2 = root1;
                error = string.Empty;
                return 1;
            }

            // Основна гілка: D > 0 (два корені)
            double sqrtD = Math.Sqrt(d);
            root1 = (-B + sqrtD) / (2 * A);
            root2 = (-B - sqrtD) / (2 * A);
            error = string.Empty;
            return 2;
        }
    }

    /// <summary>
    /// Представляє кубічну функцію вигляду y = ax^3 + bx^2 + cx + d (Варіант 4).
    /// </summary>
    public class CubicEquation
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public CubicEquation(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        /// <summary>
        /// Обчислює значення кубічної функції у точці x.
        /// Застосовано рефакторинг: Inline Temp.
        /// </summary>
        public double Calculate(double x) => A * x * x * x + B * x * x + C * x + D;
    }
}
