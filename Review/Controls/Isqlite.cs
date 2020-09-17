using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review.Controls
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
