export class FinanaceDetails {
  PMId: number;
  LoanHolderName: string;
  LoanType: string;
  LoanDate: string;
  InsuranceDate: string;
}

export interface ProgressStatus {
  status: ProgressStatusEnum;
  percentage?: number;
}

export enum ProgressStatusEnum {
  START, COMPLETE, IN_PROGRESS, ERROR
}

