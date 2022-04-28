import { MonitoringApproach } from "./monitoring-approach";

export interface MonitoringConcern {
    id: string;
    label: string;
    isChecked: boolean;
    approaches: MonitoringApproach[];
}
