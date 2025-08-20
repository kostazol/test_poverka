using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoverkaWinForms.Exceptions;

namespace PoverkaWinForms.UI;

public static class UiHelper
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
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
