export default interface Application {
    id: string; // Guid is typically represented as a string in TypeScript
    companyName: string;
    jobTitle: string;
    jobDescription?: string; // Optional properties use the '?' symbol
    jobLink?: string;
}
