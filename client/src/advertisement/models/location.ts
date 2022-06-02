import {Country} from "./country";
import {City} from "./city";

export class Location {
    id: string = '';
    country: Country = new Country();
    city: City = new City();
    address: string = '';
    geolocation: string = '';
}