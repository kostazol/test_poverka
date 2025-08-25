using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoverkaWinForms.Exceptions;

namespace PoverkaWinForms.Forms;

public static class FormHelper
{
    public static async Task RunSafeAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (ServerUnavailableException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (ApiException ex)
        {
            var statusCode = (int)ex.StatusCode;
            var message = statusCode >= 500
                ? "Произошла неизвестная ошибка"
                : $"Ошибка с кодом {statusCode}, текст ошибки: {ex.Message}";
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
