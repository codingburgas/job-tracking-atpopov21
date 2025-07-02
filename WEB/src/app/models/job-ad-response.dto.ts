export interface JobAdResponseDTO {
  id: number;
  title: string;
  companyName: string;
  description: string;
  location: string;
  postedDate: string; // ISO date string
  salaryRange: number;
}
