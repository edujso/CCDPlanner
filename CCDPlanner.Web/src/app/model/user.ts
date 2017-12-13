export interface User {
    id: string;
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    email: string;
    claims: any[];
    token: string;
}
