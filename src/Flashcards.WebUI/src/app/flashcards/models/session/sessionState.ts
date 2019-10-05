import {SessionCard} from './sessionCard';

export interface SessionState {
  id: string;
  userId: string;
  deck: string;
  isFinished: boolean;
  card: SessionCard;
  totalCount: number;
  actualCount: number;
  percentage: number;
}
