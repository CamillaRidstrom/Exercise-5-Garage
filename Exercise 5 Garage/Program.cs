using Exercise_5_Garage;

public class Program
{
    /*  KOMMENTAR:

    Programmet har alltså all funktionalitet som efterfrågades 
    samt Unit Test (två test som testar en av (de två) publika funktionerna i Garage).

    Men inte alla subklasser även om alla typerna av fordon finns.
    Jag tror (?) programmet följer strukturritningen vi fick, men utan interfaceversioner. 

    (Det finns ytterligare kommentarer i Handler, Garage och Vehicle).

    */

    public static void Main(string[] args)
    {
        Manager manager = new Manager();
        manager.Start();
    }
}