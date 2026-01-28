import Foundation
import CryptoKit

// MARK: - INCIDENT RESPONSE PLAN

func incidentResponsePlan() {
    print("""
    ===== INCIDENT RESPONSE PLAN =====

    Detection Method:
    - Continuous system log monitoring and intrusion detection systems (IDS)
      are used to identify unusual network activity or unauthorized access.

    Containment Strategy:
    - Immediately isolate affected systems from the network
      to prevent further spread of the attack.

    Eradication:
    - Remove malicious software, revoke compromised credentials,
      and patch system vulnerabilities.

    Recovery:
    - Restore systems from secure backups.
    - Monitor systems for abnormal activity before returning to normal operation.

    Cyber Attack Example – Ransomware:
    - Ransomware encrypts critical files and demands payment for decryption.
    - This plan mitigates ransomware by isolating infected systems,
      removing malware, and restoring data from backups.
    """)
}

// MARK: - SECURITY POLICY & CIA TRIAD

func securityPolicy() {
    print("""
    ===== SECURITY POLICY =====

    Key Security Rules:
    1. Strong passwords and multi-factor authentication are required.
    2. Sensitive data must be encrypted both at rest and in transit.
    3. Regular system updates and security patches must be applied.

    CIA Triad Explanation:
    - Confidentiality: Encryption ensures sensitive data is protected.
    - Integrity: Hashing verifies that data has not been altered.
    - Availability: Incident response and backups ensure systems remain accessible.

    Incident Response Integration:
    - Policies ensure rapid detection, response, and recovery during security incidents.
    """)
}

// MARK: - ENCRYPTION & HASHING DEMO (AES + SHA256)

func encryptionDemo() {
    let plainText = "Cybersecurity is important"
    let key = SymmetricKey(size: .bits256)

    // Encrypt using AES-GCM
    let encryptedData = try! AES.GCM.seal(plainText.data(using: .utf8)!, using: key)

    // Decrypt
    let decryptedData = try! AES.GCM.open(encryptedData, using: key)
    let decryptedText = String(data: decryptedData, encoding: .utf8)!

    // Hash using SHA256
    let hash = SHA256.hash(data: plainText.data(using: .utf8)!)
    let hashString = hash.map { String(format: "%02hhx", $0) }.joined()

    print("""
    ===== ENCRYPTION & HASHING =====

    Plain Text:
    \(plainText)

    Encrypted Text:
    \(encryptedData.ciphertext.base64EncodedString())

    Decrypted Text:
    \(decryptedText)

    SHA-256 Hash:
    \(hashString)
    """)
}

// MARK: - LEGAL & ETHICAL COMPLIANCE

func legalEthicalCompliance() {
    print("""
    ===== LEGAL & ETHICAL COMPLIANCE =====

    Relevant Laws & Regulations:
    1. GDPR (General Data Protection Regulation):
       - Protects personal data and requires breach notification.
    2. HIPAA (Health Insurance Portability and Accountability Act):
       - Safeguards sensitive healthcare information.

    Ethical Considerations:
    - Ensuring user privacy and responsible handling of sensitive data.
    - Transparency when security breaches occur.

    Compliance Explanation:
    - Encryption and access controls ensure legal data protection.
    - Incident response procedures support ethical disclosure
      and accountability during security events.
    """)
}

// MARK: - PROGRAM EXECUTION

incidentResponsePlan()
securityPolicy()
encryptionDemo()
legalEthicalCompliance()

