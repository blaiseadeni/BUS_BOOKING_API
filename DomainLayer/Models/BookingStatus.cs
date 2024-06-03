namespace DomainLayer.Models
{
    public enum BookingStatus
    {
        Pending,        // En attente de confirmation
        Confirmed,      // Réservation confirmée
        Cancelled,      // Réservation annulée
        Completed       // Réservation terminée (le voyage est terminé)
    }
}
