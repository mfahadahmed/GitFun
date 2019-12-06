export interface Repository {
    id: string;
    name: string;
    description: string;
    url: string;
    lastUpdated: Date;
    isPublic: boolean;
    isStarred: boolean;
    commits?: string[];
    branches?: string[];
}
