import { Project } from './project';
import { Repository } from './repository';

export interface User {
    id?: string;
    name?: string;
    username?: string;
    password?: string;
    emailAddress?: string;
    phone?: string;
    company?: string;
    city?: string;
    country?: string;
    photoUrl?: string;
    projects?: Project[];
    repositories?: Repository[];
}
