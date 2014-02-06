namespace BusinessLib
{
    /// <summary>
    /// A data source that provides raw data objects.  In a real
    /// application this class would make calls to a database.
    /// </summary>
    public static class Database
    {
        #region GetRegions

        public static Region[] GetRegions()
        {
            return new Region[]
            {
                new Region("Northeast"),
                new Region("Midwest")
            };
        }

        #endregion // GetRegions

        #region GetStates

        public static State[] GetStates(Region region)
        {
            switch (region.RegionName)
            {
                case "Northeast":
                    return new State[]
                    {
                        new State("Connecticut"),
                        new State("New York")
                    };

                case "Midwest":
                    return new State[]
                    {
                        new State("Indiana")
                    };
            }

            return null;
        }

        #endregion // GetStates

        #region GetCities

        public static City[] GetCities(State state)
        {
            switch (state.StateName)
            {
                case "Connecticut":
                    return new City[]
                    {
                        new City("Bridgeport"),
                        new City("Hartford"),
                        new City("New Haven")
                    };

                case "New York":
                    return new City[]
                    {
                        new City("Buffalo"),
                        new City("New York"),
                        new City("Syracuse")          
                    };

                case "Indiana":
                    return new City[]
                    {
                        new City("Evansville"),
                        new City("Fort Wayne"),
                        new City("Indianapolis"),
                        new City("South Bend")
                    };
            }

            return null;
        }

        #endregion // GetCities

        #region GetFamilyTree

        public static Person GetFamilyTree()
        {
            // In a real app this method would access a database.
            return new Person
            {
                Name = "David Weatherbeam",
                Children =
                {
                    new Person
                    {
                        Name="Alberto Weatherbeam",
                        Children=
                        {
                            new Person
                            {
                                Name="Zena Hairmonger",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="Sarah Applifunk",
                                    }
                                }
                            },
                            new Person
                            {
                                Name="Jenny van Machoqueen",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="Nick van Machoqueen",
                                    },
                                    new Person
                                    {
                                        Name="Matilda Porcupinicus",
                                    },
                                    new Person
                                    {
                                        Name="Bronco van Machoqueen",
                                    }
                                }
                            }
                        }
                    },
                    new Person
                    {
                        Name="Komrade Winkleford",
                        Children=
                        {
                            new Person
                            {
                                Name="Maurice Winkleford",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="Divinity W. Llamafoot",
                                    }
                                }
                            },
                            new Person
                            {
                                Name="Komrade Winkleford, Jr.",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="Saratoga Z. Crankentoe",
                                    },
                                    new Person
                                    {
                                        Name="Excaliber Winkleford",
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        #endregion // GetFamilyTree
    }
}