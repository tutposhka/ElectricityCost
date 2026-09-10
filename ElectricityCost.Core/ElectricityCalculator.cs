namespace ElectricityCost.Core
{
    public static class ElectricityCalculator
    {
        public static bool TryCalculate(
            decimal powerWatts,
            decimal hoursPerDay,
            decimal pricePerKwh,
            out decimal energyKwh,
            out decimal cost,
            out string error)
        {
            energyKwh = 0;
            cost = 0;
            error = "";

            if (powerWatts <= 0 || powerWatts > 100000)
            {
                error = "Võimsus peab olema suurem kui 0 ja kuni 100000 W";
                return false;
            }

            if (hoursPerDay <= 0 || hoursPerDay > 24)
            {
                error = "Töötunnid päevas peavad olema vahemikus 0 kuni 24";
                return false;
            }

            if (pricePerKwh <= 0 || pricePerKwh > 10)
            {
                error = "Elektri hind peab olema suurem kui 0 ja kuni 10 €/kWh";
                return false;
            }

            energyKwh = (powerWatts / 1000) * hoursPerDay * 30;
            cost = energyKwh * pricePerKwh;

            energyKwh = Math.Round(energyKwh, 2, MidpointRounding.AwayFromZero);
            cost = Math.Round(cost, 2, MidpointRounding.AwayFromZero);

            return true;
        }
    }
}