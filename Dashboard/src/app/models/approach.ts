export interface Approach {
    id: number;
    name: string;
    description: string;
    isChecked: boolean;
    implementationDifficulty: 'easy' | 'medium' | 'hard';
    maintenanceDifficulty: 'easy' | 'medium' | 'hard';
    concernId: number;
}
