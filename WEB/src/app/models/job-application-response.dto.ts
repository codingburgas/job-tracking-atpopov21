export interface JobApplicationResponseDTO {
  id: number;
  userId: number;
  jobTitle: string;
  companyName: string;
  status: string;
  appliedDate: string; // ISO date string
}
