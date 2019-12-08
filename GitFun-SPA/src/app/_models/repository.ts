export interface Repository {
    id?: string;
    name?: string;
    description?: string;
    url?: string;
    lastUpdated?: Date;
    isPublic?: boolean;
    isStarred?: boolean;
    owner?: string;
    files?: string[];
    commits?: string[];
    branches?: string[];
}
