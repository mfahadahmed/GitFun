import { Project } from './project';
import { Repository } from './repository';

export interface User {
    id: string;
    name: string;
    password: string;
    username: string;
    emailAddress: string;
    phone: string;
    company?: string;
    city?: string;
    country?: string;
    projects?: Project[];
    repositories?: Repository[];
}
