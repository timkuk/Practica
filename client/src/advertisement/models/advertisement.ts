import {Location} from "./location";

export class Advertisement {
    id: string = '';
    title: string = '';
    price: number = 0;
    rooms: number = 0;
    livingArea: number = 0;
    floor: number = 0;
    images: string[] = [];
    description: string = '';
    isActive: boolean = false;
    publicationDate: string = '';
    location: Location = new Location();
}