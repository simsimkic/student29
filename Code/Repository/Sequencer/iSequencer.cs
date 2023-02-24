using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository.Sequencer
{
    public interface iSequencer<T>
    {
        void Initialize(T initId);

        T GenerateId();
    }
}
