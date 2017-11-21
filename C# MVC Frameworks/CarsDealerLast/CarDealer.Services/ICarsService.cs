﻿namespace CarDealer.Services
{
    using CarDealer.Services.Models.Cars;
    using System.Collections.Generic;

    public interface ICarsService
    {
        IEnumerable<CarModel> All();

        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> AllWithParts();
    }
}
