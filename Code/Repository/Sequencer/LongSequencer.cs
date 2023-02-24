using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinicClassDiagram.Repository.Sequencer
{
    public class LongSequencer : iSequencer<long>
    {
        private long _nextId;

        public long GenerateId() => ++_nextId;

        public void Initialize(long initId) => _nextId = initId;
    }
}
