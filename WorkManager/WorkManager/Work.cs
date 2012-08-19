using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public interface Work<E>
    {

        void updateProgress(E item);

        int getProgress();

        String getWorkId();

    }
}
