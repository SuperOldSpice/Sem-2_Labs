using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09Library
{
    public class Phone
    {
        private event PhoneStateHandler Notify;

        private int _talk_time = 0;
        private decimal _sum = 0;
        private bool _activated = false;
        private string _name = null;

        public Phone(string name, PhoneStateHandler e)
        {
            _name = name;
            this.Notify += e;
            Notify?.Invoke(this, new PhoneEventArgs("Phone " + _name + " was created", _sum));        
        }
        
        public void ActivatePhone()
        {
            _activated = true;
            Notify?.Invoke(this, new PhoneEventArgs("Your phone " + _name + " was activated", _sum));
        }

        public void Put(decimal money)
        {
            _sum += money;
            Notify?.Invoke(this, new PhoneEventArgs("Your balance " + _sum , _sum));
        }

        public void Talk(int hour)
        {
            if (_activated)
            {
                if (hour > 0)
                {
                    _talk_time += hour;
                    _sum -= hour * 10;
                    Notify?.Invoke(this, new PhoneEventArgs("You has talked for all time: " + _talk_time, _sum));
                }
            }
            else
            {
                Notify?.Invoke(this, new PhoneEventArgs("Your phone wasnt activated ", _sum));
            }
        }

        public void CheckStatus()
        {
            if(_activated)
                Notify?.Invoke(this, new PhoneEventArgs("Your phone is activated and your current balance is: " 
                    + _sum +",\nyou has talked " + _talk_time + " hours for all time", _sum));
            else
                Notify?.Invoke(this, new PhoneEventArgs("Your phone wasnt activated ", _sum));
        }       

    }
}
