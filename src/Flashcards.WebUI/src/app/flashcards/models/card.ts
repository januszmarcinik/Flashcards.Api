export interface Card {
  id: string;
  question: string;
  answer: string;
  previousCardId: string;
  nextCardId: string;
  confirmed: boolean;
}
