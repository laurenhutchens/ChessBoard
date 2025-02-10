/* 
 * Lauren Hutchens
 * CST-250
 * 2/9/2025 
 * Activity 2: Chess Board App
 * In class activity
 */
namespace ChessBoardGUIApp
{
    internal static class Program
    {
        //adding
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmChessBoard());
        }
    }
}