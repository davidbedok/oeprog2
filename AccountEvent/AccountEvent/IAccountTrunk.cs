using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent
{
    /*
     * A peldaban hasznalt Interface-ben csak olyan elemek vannak, melyeket peldany szinten is tudunk hivni.
     * Az Interface segitsegevel meg lehet mutatni, hogy ket kulonbozo implementacio is lehet azonos mukodesu.
     */
    public interface IAccountTrunk
    {
        // felvesz egy szoveges esemenyt
        void addEvent(string message, string accountNumber, DateTime date);
        
        // felvesz egy atutalasi esemenyt
        void addEvent(string targetAccountNumber, double value, string accountNumber, DateTime date);
        
        // felvesz egy penzszamlat
        void addAccount(double moneyBalance, string ownerName, string accountNumber);

        // felvesz egy ertekpapir szamlat
        void addAccount(string instrumentName, int number, string ownerName, string accountNumber);

        // visszaadja a torzs teljes erteket
        double getAllTrunkValue();

        // visszaadja a torzs erteket egy adott szemelyre nezve
        double getAllTrunkValue(string ownerName);

        // visszaadja a torzsben szereplo szemelyekre bontva a torzs erteket
        string getPeopleValue();

        /*
         * Ha az Account nem abstract (egyszerubb eset), akkor a tovabbi metodusok is ertelmezettek
         */

        // felvesz egy szamlat (Az Account lehetne abstract, es akkor erre nincs szukseg)
        void addAccount(string ownerName, string accountNumber);

        // felvesz egy szamlat es bellitja egyenleget (Az Account lehetne abstract es egyenleg nelkuli, es akkor erre nincs szukseg)
        void addAccount(string ownerName, string accountNumber, double balance);

        // visszaadja a torzs penzerteket
        double getTrunkValue();

    }
}
